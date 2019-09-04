using UnityEngine;
using System.Collections;

public class RotatingPlatform : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.gameObject.transform.RotateAround (transform.position, Vector3.forward, -10 * Time.deltaTime);
	}
}

