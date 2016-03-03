using UnityEngine;
using System.Collections;

public class Darkness : MonoBehaviour {
    public Indicator scriptIndicator;
    public GameObject _torch;
	
    public bool hasLight;

    public AudioClip darkness;
    public AudioSource audioSource;

    // Use this for initialization
    void Start()
    {

        scriptIndicator = GameObject.FindGameObjectWithTag("Collectable").GetComponent<Indicator>();

      //find the objects
        _torch = GameObject.FindGameObjectWithTag("torch");

      //hide objects
        _torch.gameObject.SetActive(false);

        hasLight = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (!audioSource.isPlaying && !hasLight)
        {
            audioSource.clip = darkness;
            audioSource.PlayOneShot(audioSource.clip);
        }
        if (hasLight)
        {
            audioSource.Stop();
        }
        if (scriptIndicator.torch == true)
        {
            _torch.gameObject.SetActive(true);
            hasLight = true;
        }

    }
}
