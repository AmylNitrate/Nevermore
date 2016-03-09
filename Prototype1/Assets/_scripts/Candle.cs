using UnityEngine;
using System.Collections;

public class Candle : MonoBehaviour 
{
	public SpriteRenderer m_renderer;
	public Sprite m_sprite;
	public Sprite m_spriteNone;
	public bool indicatorOn;
	public GameObject flames;

	float timer;
	// Use this for initialization
	void Start () 
	{
		m_renderer = gameObject.GetComponentInChildren<SpriteRenderer> ();
		indicatorOn = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (indicatorOn) 
		{
			if (Input.GetButtonDown ("Space")) 
			{
				if (Data.control.Matches > 0) {
					Data.control.Matches--;
					flames.SetActive (true);
					GameObject.FindGameObjectWithTag ("Player").GetComponent<Darkness> ().hasLight = true;
					timer = 5;
				} else if (Data.control.Matches <= 0) {
					Debug.Log ("NO MATCHES");
				}
			}
		}

		timer -= Time.deltaTime;

		if (timer <= 0) 
		{
			flames.SetActive (false);
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Darkness> ().hasLight = false;
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
