using UnityEngine;
using System.Collections;

public class Darkness : MonoBehaviour {

    public bool hasLight;
    public AudioClip darkness;
    public AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
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

    }
}
