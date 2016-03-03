using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public float _speed;
	public iTween.EaseType curve;
	public bool _doorReady;

	//public AudioClip m_doorsound;
	//public AudioSource audiosource;

	// Use this for initialization
	void Start () 
	{
		_doorReady = false;
		_speed = 2f;

	}

	void Update () 
	{
		
		if (_doorReady) 
		{
			
			if (Input.GetKeyDown (KeyCode.O)) 
			{
				iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0,100,0), "time", _speed, "easetype", curve));
				//audiosource.clip = m_doorsound;
			}
			if (Input.GetKeyDown (KeyCode.P)) 
			{
				iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0,0,0), "time", _speed, "easetype", curve));
			}
			
		}
		
	}
	
	void OnTriggerEnter()
	{
		_doorReady = true;
		
	}
	
	void OnTriggerExit()
	{
		_doorReady = false;
	}
	

}
