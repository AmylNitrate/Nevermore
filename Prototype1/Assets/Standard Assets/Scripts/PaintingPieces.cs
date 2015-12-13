using UnityEngine;
using System.Collections;

public class PaintingPieces : MonoBehaviour {

	public SpriteRenderer m_renderer;
	public Sprite m_sprite;
	public Sprite m_spriteNone;
	public bool indicatorOn;
	
	[SerializeField] public FirstPersonController fps;
	public GameObject pocket;
	public bool inspecting;
	public Vector3 OriginalPosition;
	
	public float speed = 50;

	//public bool hasObject;
	public GameObject paintingpocket;

	// Use this for initialization
	void Start () 
	{
		
		m_renderer = gameObject.GetComponentInChildren<SpriteRenderer> ();
		indicatorOn = false;
		fps = gameObject.GetComponent<FirstPersonController> ();
		inspecting = false;

		//hasObject = false;
		
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
					fps.yes = false;
					m_renderer.sprite = m_spriteNone;
					OriginalPosition = gameObject.transform.position;
					gameObject.transform.position = pocket.transform.position;
					inspecting = true;
					
				}
				else if (inspecting == true) 
				{
					if(gameObject.tag.Equals("Painting"))
					{
						fps.yes = true;
						gameObject.transform.position = paintingpocket.transform.position;
						inspecting = false;
					}
					else
					{
						fps.yes = true;
						gameObject.transform.position = OriginalPosition;
						inspecting = false;
					}

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
