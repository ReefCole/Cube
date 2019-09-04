using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraSomething : MonoBehaviour
{
	public GameObject cam;
	public GameObject camPoint;
	// Use this for initialization
	void Start ()
	{
	}
	
	// On trigger
	void OnTriggerEnter (Collider other)
    {
            if (other.tag == "Player")
            {
			    while (cam.transform.position != camPoint.transform.position)
			{
				cam.transform.position += (camPoint.transform.position - camPoint.transform.position)/10;
			}
            }
    }
}

