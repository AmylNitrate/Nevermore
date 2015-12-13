﻿using UnityEngine;
using System.Collections;

public class CandleIndicator : MonoBehaviour {

	public SpriteRenderer m_renderer;
	public Sprite m_sprite;
	public Sprite m_spriteNone;
	public bool indicatorOn;
	
	[SerializeField] public FirstPersonController fps;
	public GameObject pocket;
	public bool inspecting;
	public Vector3 OriginalPosition;
	//public Vector3 OriginalAngles;
	
	public float speed = 50;

	// Use this for initialization
	void Start () 
	{
		
		m_renderer = gameObject.GetComponentInChildren<SpriteRenderer> ();
		indicatorOn = false;
		fps = GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ();
		inspecting = false;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (indicatorOn) 
		{
			OriginalPosition = gameObject.transform.position;
			//OriginalAngles = gameObject.transform.position;
			if (Input.GetButtonDown ("Space")) 
			{
				if (inspecting == false) 
				{
					fps.yes = false;
					m_renderer.sprite = m_spriteNone;
					OriginalPosition = gameObject.transform.position;
					gameObject.transform.position = pocket.transform.position;
					inspecting = true;
					
				}
				else if (inspecting == true) 
				{
					fps.yes = true;
					gameObject.transform.position = OriginalPosition;
					//gameObject.transform.eulerAngles = OriginalPosition;
					inspecting = false;
				}
				
			}
		}
		
		if(inspecting)
		{
			if (Input.GetKey(KeyCode.A))
				gameObject.transform.Rotate(Vector3.up * speed * Time.deltaTime);
			if (Input.GetKey(KeyCode.D))
				gameObject.transform.Rotate(-Vector3.up * speed * Time.deltaTime);
			if (Input.GetKey(KeyCode.W))
				gameObject.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
			if (Input.GetKey(KeyCode.S))
				gameObject.transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
		}
		
		
	}
	
	void OnTriggerEnter()
	{
		m_renderer.sprite = m_sprite;
		indicatorOn = true;
		
	}
	
	void OnTriggerExit()
	{
		m_renderer.sprite = m_spriteNone;
		indicatorOn = false;
	}
}


