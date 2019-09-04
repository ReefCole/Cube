using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSelfDestruct : MonoBehaviour {

    // Use this for initialization
    private AudioSource SoundSource;
	void Start ()
    {
        SoundSource = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!SoundSource.isPlaying)
        {
            Destroy(this.gameObject);
        }	
	}
}
