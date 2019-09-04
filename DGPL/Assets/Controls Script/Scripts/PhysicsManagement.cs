using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManagement : MonoBehaviour
{

    LimbManagement LimbManager;
    private Rigidbody CubeRigidBody;
    public float DegradationSpeed = 0.0001f;
    // Use this for initialization
    void Start()
    {
        LimbManager = this.gameObject.GetComponent<LimbManagement>();
        CubeRigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixedUpdate()
    {

        List<float> speeds = new List<float>();
        for (int i = 0; i < 4; i++)
        {
            float newValue = this.gameObject.GetComponent<Animator>().GetFloat("Limb" + (i + 1).ToString() + "Speed");
            speeds.Add(newValue);
        }

        Vector3 massCenter = CubeRigidBody.centerOfMass;
        if (speeds[0] == 0 && speeds[1] == 0 && speeds[2] == 0 && speeds[3] == 0)
            //this.gameObject.GetComponent<Rigidbody>().centerOfMass = new Vector3();
            CubeRigidBody.centerOfMass = Vector3.Lerp(massCenter, new Vector3(), DegradationSpeed);
    }

    public void ManualCenterOfGravity()
    {
        //Vector3 CenterPoint1 = LimbManager.Limbs[LimbManager.GetLimbNumber("Up")].transform.position +
        
        Vector3 CenterOfGravity = new Vector3();
        for (int i = 0; i < 4; i++)
        {
            CenterOfGravity += this.gameObject.transform.InverseTransformPoint(LimbManager.Limbs[i].transform.position);
        }
        CenterOfGravity = (CenterOfGravity / 4) * 22f;
        //Debug.Log(CenterOfGravity);

        CubeRigidBody.centerOfMass = CenterOfGravity;

        //rb.AddForceAtPosition(Physics.gravity, CenterOfGravity, ForceMode.Impulse);
        //Debug.Log(CenterOfGravity);
        //Debug.DrawLine(CenterOfGravity, CenterOfGravity + Vector3.right, Color.red);
        //Debug.Log(this.gameObject.transform.InverseTransformPoint(CenterOfGravity / 4));
    }
}

