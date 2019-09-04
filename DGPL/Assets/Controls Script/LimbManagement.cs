using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
    
public class LimbManagement : MonoBehaviour {

    public Dictionary<string, int> LimbDirections = new Dictionary<string, int>();
    public Dictionary<GameObject, int> LimbDictionary = new Dictionary<GameObject, int>();
    public Dictionary<GameObject, int> AnchorDictionary = new Dictionary<GameObject, int>();
    public List<GameObject> Limbs;
    public GameObject Body;

	// Use this for initialization
	void Start ()
    {
        LimbDictionary.Add(Limbs[0], 1);
        LimbDictionary.Add(Limbs[1], 2);
        LimbDictionary.Add(Limbs[2], 3);
        LimbDictionary.Add(Limbs[3], 4);
        LimbDirections.Add("Up", 1);
        LimbDirections.Add("Down", 2);
        LimbDirections.Add("Left", 3);
        LimbDirections.Add("Right", 4);
        ResetLimbDirections();
	}
	
	// Update is called once per frame
	void Update ()
    {
        

    }
    void FixedUpdate()
    {
        //MoveLimbColliders();
    }
    

    public void ResetLimbDirections()
    {
        GameObject TopLimb = Limbs[0];
        GameObject BottomLimb = Limbs[1];
        GameObject LeftLimb = Limbs[2];
        GameObject RightLimb = Limbs[3];

        //Set Top Limb
        foreach (var limb in Limbs)
        {
            if (limb.transform.position.y > TopLimb.transform.position.y)
            {

                TopLimb = limb;
            }
        }
        //Set Bottom Limb
        foreach (var limb in Limbs)
        {
            if (limb.transform.position.y < BottomLimb.transform.position.y)
            {
                BottomLimb = limb;
            }
        }
 
        //Set Left Limb
        foreach (var limb in Limbs)
        {
            if (limb.transform.position.x < LeftLimb.transform.position.x)
            {
                LeftLimb = limb;
            }
        }
		
        //Set Right Limb
        foreach (var limb in Limbs)
        {
            if (limb.transform.position.x > RightLimb.transform.position.x)
            {
                RightLimb = limb;
            }
        }
        LimbDirections["Up"] = LimbDictionary[TopLimb];
        LimbDirections["Down"] = LimbDictionary[BottomLimb];
        LimbDirections["Left"] = LimbDictionary[LeftLimb];
        LimbDirections["Right"] = LimbDictionary[RightLimb];

        Debug.Log(LimbDirections["Up"]);
        Debug.Log(LimbDirections["Down"]);
        Debug.Log(LimbDirections["Left"]);
        Debug.Log(LimbDirections["Right"]);
    }

    public int GetLimbNumber(string aDirection)
    {
        return LimbDirections[aDirection];
    }

}
