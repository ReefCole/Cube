using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> Limbs = new List<GameObject>();
    private List<AudioSource> AudioSources = new List<AudioSource>();
    public AudioClip ExtendSound;
    public AudioClip RetractSound;
    public GameObject SoundSourcePrefab;

	void Start ()
    {
        foreach (GameObject limb in Limbs)
        {
            AudioSources.Add(limb.GetComponent<AudioSource>());
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > 0.02)
        {
            GameObject soundObject = (GameObject)Instantiate(SoundSourcePrefab, collision.contacts[0].point, Quaternion.identity);
            AudioSource soundSource = soundObject.GetComponent<AudioSource>();
            soundSource.Play();
        }
    }

    public void PlaySound(int SourceNo, string type)
    {
        AudioClip usedSound;
        if (type == "extend")
            usedSound = ExtendSound;
        else
            usedSound = RetractSound;
        
        if (!AudioSources[SourceNo].isPlaying)
            AudioSources[SourceNo].PlayOneShot(usedSound,.2f);
    }
    
}
