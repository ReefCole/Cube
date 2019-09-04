using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManagement : MonoBehaviour
{

    // Use this for initialization
    public ParticleSystem DustParticles;
    public List<ContactPoint> Staypoints = new List<ContactPoint>();

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        Staypoints.Clear();

        foreach (ContactPoint contact in collision.contacts)
        {
            Staypoints.Add(contact);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0.02)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                if (!Staypoints.Contains(contact))
                    Instantiate(DustParticles, contact.point, Quaternion.identity);
            }
        }

    }
}