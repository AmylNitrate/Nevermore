using UnityEngine;
using System.Collections;
using System;

public class GameHandler : MonoBehaviour {

	public static GameHandler handler;

	float _speed = 2f;
	iTween.EaseType curve;
	public GameObject studyDoor, laundryDoor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FaxMachine()
	{
		Debug.Log ("faxing");
		//fax audio
		//fax animation

		//sift between notes somehow
	}

	public void TriggerOne()
	{
		//activate game objects
		//door audio
		iTween.RotateTo (studyDoor, iTween.Hash ("rotation", new Vector3 (0, 100, 0), "time", _speed, "easetype", curve));

		//candles ON (loungroom, kitchen, upstairs)
	}

	public void TriggerTwo()
	{
		//Audio(door open)

		iTween.RotateTo (laundryDoor, iTween.Hash ("rotation", new Vector3 (0, 100, 0), "time", _speed, "easetype", curve));

		//Laundry lights ON
	}


}
