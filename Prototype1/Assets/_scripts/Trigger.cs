using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	bool handler = GameObject.Find ("GameController").GetComponent<GameHandler> ().play = true;
	}
}
