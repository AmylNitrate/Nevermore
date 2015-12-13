using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour {

	public Indicator scriptIndicator;
	public GameObject _torch;

	// Use this for initialization
	void Start () {

		scriptIndicator = GameObject.FindGameObjectWithTag ("Collectable").GetComponent<Indicator> ();
		_torch = GameObject.FindGameObjectWithTag("torch");
		_torch.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if (scriptIndicator.torch == true) 
		{
			_torch.gameObject.SetActive(true);
		}
	
	}
}
