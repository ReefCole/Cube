using UnityEngine;
using System.Collections;

public class RisingPlatform : MonoBehaviour
{
	public GameObject Platform;
	public bool up = true;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{ 
		if (transform.position.y >= 6.5)
		{
			up = false;
		}

		if (transform.position.y <= 0)
		{
			up = true;
		}

		if (up == true)
		{
		    transform.Translate(Vector3.up * Time.deltaTime);
		}

		else
		{
		    transform.Translate(Vector3.down * Time.deltaTime);
		}
		//transform.RotateAround (transform.position, Vector3.forward, -10 * Time.deltaTime);
	}
}

