using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {

	public static GameHandler handler;

	float _speed = 2f;
	iTween.EaseType curve;
	public GameObject studyDoor, laundryDoor, paper, paper2, paper3;
	public AudioSource faxsource, radiosource, phonesource;
	public AudioClip fax, radio, call;

	Text textRef1;

	public bool play;

	// Use this for initialization
	void Start () {
		play = false;

		textRef1 = GameObject.Find ("Info").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (play) {
			TriggerOne ();
		}
	}

	public void FaxMachineOne()
	{
		paper.SetActive (true);
		faxsource.PlayOneShot (fax);
		//fax audio
		//fax animation

	}
	public void FaxMachineTwo()
	{
		paper2.SetActive (true);
		faxsource.PlayOneShot (fax);
		//fax audio
		//fax animation

	}
	public void FaxMachineThree()
	{
		paper3.SetActive (true);
		faxsource.PlayOneShot (fax);
		//fax audio
		//fax animation

	}

	public void TriggerOne()
	{
		//activate game objects
		//door audio]
		textRef1.text = "";
		iTween.RotateTo (studyDoor, iTween.Hash ("rotation", new Vector3 (0, 100, 0), "time", _speed, "easetype", curve));

		//Activate GameObjects(Mail in study)
		//candles ON (loungroom, kitchen, upstairs)
	}
		 

	public void TriggerTwo()
	{
		//Audio(door open)

		iTween.RotateTo (laundryDoor, iTween.Hash ("rotation", new Vector3 (0, 100, 0), "time", _speed, "easetype", curve));

		//Laundry lights ON
	}

	public void Radio()
	{
		radiosource.PlayOneShot (radio);
	}

	public void EmergencyCall()
	{
		phonesource.PlayOneShot (call);
	}

}
