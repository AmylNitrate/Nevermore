using UnityEngine;
using System.Collections;

public class Indicator : MonoBehaviour {

	public SpriteRenderer m_renderer;
	public Sprite m_sprite;
	public Sprite m_spriteNone;
	public bool indicatorOn;
	[SerializeField] public FirstPersonController fps;
	public bool inspecting;
	public GameObject thisObject;

	// Use this for initialization
	void Start () 
	{

		m_renderer = gameObject.GetComponentInChildren<SpriteRenderer> ();
		indicatorOn = false;
		fps = GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ();
		inspecting = false;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (indicatorOn) 
		{
			if (Input.GetButtonDown ("Space")) 
			{

				if (inspecting == false) 
				{
					if (gameObject.tag.Equals ("Object")) 
					{
						fps.yes = false;
						m_renderer.sprite = m_spriteNone;
						gameObject.GetComponent<MeshRenderer> ().enabled = false;
						thisObject.SetActive (true);
						inspecting = true;
					} 
					else if (gameObject.tag.Equals ("Collectable")) 
					{
						thisObject.SetActive (true);
						Destroy (gameObject);
					} 

					
				} 
				else if (inspecting == true) 
				{
					fps.yes = true;
					gameObject.GetComponent<MeshRenderer> ().enabled = true;
					thisObject.SetActive (false);
					inspecting = false;
				}

				
			}
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
