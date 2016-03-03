using UnityEngine;
using System.Collections;

public class endgame : MonoBehaviour 
{
	public SpriteRenderer m_renderer;
	public Sprite black;
	public AudioClip FX1;
	public AudioSource m_audiosource;

	// Use this for initialization
	void Start () 
	{
		m_audiosource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			m_renderer.sprite = black;
			m_audiosource.clip = FX1;
			m_audiosource.PlayOneShot(FX1);
		}
	
	}
}
