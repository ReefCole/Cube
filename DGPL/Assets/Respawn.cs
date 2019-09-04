using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
	public GameObject spawnPoint;
	public float x, y, z;
	// Use this for initialization
	//void Start ()
	//{
	//}
	
	// On trigger
	void OnTriggerEnter (Collider other)
    {
            if (other.tag == "Player")
            {
			other.transform.rotation = Quaternion.identity;
			other.transform.position = spawnPoint.transform.position;
			//other.transform.position = new Vector3(x, y, z);
			Debug.Log ("triggered");
            }
    }
}

