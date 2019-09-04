using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    // Use this for initialization
    public Transform TargetTransform;
    public Vector3 offset;
    public float smoothSpeed = 0.3f;
    private Vector3 velocity = Vector3.zero;

	void Start (){
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void LateUpdate()
    {
        Vector3 desiredPosition = TargetTransform.position + offset;
        Vector3 smoothPosition = Vector3.SmoothDamp(this.gameObject.transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothPosition;
    }
}
