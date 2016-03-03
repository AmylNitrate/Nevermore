using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Text : MonoBehaviour {

    public GameObject text;

    float counter;

	// Use this for initialization
	void Start ()
    {
        counter = 56f;
        text.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {

        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            SceneManager.LoadScene("psychOffice");
        }


    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "box")
        {
            text.SetActive(true);


        }
    }

    
}
