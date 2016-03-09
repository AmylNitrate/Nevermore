using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour 
{
	public float speed = 50;

	// Use this for initialization
	void Start () 
	{
		if (gameObject.tag.Equals ("Torch")) 
		{
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Darkness> ().hasLight = true;

		}
			
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (gameObject.tag.Equals ("Object")) 
		{
			if (Input.GetKey (KeyCode.A))
				gameObject.transform.Rotate (Vector3.up * speed * Time.deltaTime);
			if (Input.GetKey (KeyCode.D))
				gameObject.transform.Rotate (-Vector3.up * speed * Time.deltaTime);
			if (Input.GetKey (KeyCode.W))
				gameObject.transform.Rotate (Vector3.forward * speed * Time.deltaTime);
			if (Input.GetKey (KeyCode.S))
				gameObject.transform.Rotate (-Vector3.forward * speed * Time.deltaTime);
		}


	}

}
