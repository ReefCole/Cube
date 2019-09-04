using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSelfDestruct : MonoBehaviour {

    // Use this for initialization
    private ParticleSystem self;
	void Start () {
        self = this.gameObject.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!self.IsAlive())
        {
            Destroy(this.gameObject);
        }
	}
}
