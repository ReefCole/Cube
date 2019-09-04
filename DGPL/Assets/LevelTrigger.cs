using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelTrigger : MonoBehaviour
{
    public string level;
	// Use this for initialization
	void Start ()
	{
	}
	
	// On trigger
	void OnTriggerEnter (Collider other)
    {
            if (other.tag == "Player")
            {
				Debug.Log ("triggered");
                SceneManager.LoadScene(level);
            }
    }
}

