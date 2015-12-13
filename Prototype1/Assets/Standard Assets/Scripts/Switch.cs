using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public bool switchready;
	public Light m_spotlight;
	public Light m_spotlight2;
	public Light m_spotlight3;
	public Light m_spotlight4;
	public MeshRenderer m_renderer;
	public Material red;
	public Material green;

	// Use this for initialization
	void Start () 
	{
		switchready = false;
		m_renderer.material = red;
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (switchready) 
		{

			if (Input.GetButtonDown ("Fire1")) 
			{
				m_renderer.material = green;
				m_spotlight.enabled = !m_spotlight.enabled;
				m_spotlight2.enabled = !m_spotlight2.enabled;
				m_spotlight3.enabled = !m_spotlight3.enabled;
				m_spotlight4.enabled = !m_spotlight4.enabled;
			}

		}
	
	}

	void OnTriggerEnter()
	{
		switchready = true;
		
	}

	void OnTriggerExit()
	{
		switchready = false;
	}
}
