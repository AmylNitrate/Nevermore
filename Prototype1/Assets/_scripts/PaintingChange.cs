using UnityEngine;
using System.Collections;

public class PaintingChange : MonoBehaviour 
{
	public SpriteRenderer m_renderer;
	public Sprite _nogirl;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter()
	{
		m_renderer.sprite = _nogirl;
	}
}
