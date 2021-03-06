﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door : MonoBehaviour {

	public float _speed;
	public iTween.EaseType curve;
	public bool _doorReady, triggerOne, locked;

	Text textRef1;
	//public AudioClip m_doorsound;
	//public AudioSource audiosource;

	// Use this for initialization
	void Start () 
	{
		_doorReady = false;
		_speed = 2f;
		textRef1 = GameObject.Find ("Info").GetComponent<Text> ();
	}

	public void Update () 
	{

		if (_doorReady) 
		{
			textRef1.text = "";
			if (Input.GetKeyDown (KeyCode.Space)) 
			{																		//(0,0,0) to close
				iTween.RotateTo (gameObject, iTween.Hash ("rotation", new Vector3 (0, 100, 0), "time", _speed, "easetype", curve));

				//audiosource.clip = openDoor;
			}
			
		}
		if (locked) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				textRef1.text = "Door Locked";
				//audiosource.clip = lockedDoor;
				GameObject.Find("GameController").GetComponent<GameHandler>().FaxMachineOne();
				//triggerOne = true;
				locked = false;
			}
		}
	}
	
	void OnTriggerEnter()
	{
		if (triggerOne) 
		{
			_doorReady = true;
		} 
		else if (!triggerOne) 
		{
			locked = true;
		}
	}
	
	void OnTriggerExit()
	{
		_doorReady = false;
	}
	

}
