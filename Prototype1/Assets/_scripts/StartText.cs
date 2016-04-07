using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartText : MonoBehaviour {

    public GameObject _text;

    float counter;

	// Use this for initialization
	void Start ()
    {
        counter = 56f;
        _text.SetActive(false);
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
            _text.SetActive(true);


        }
    }

    
}
