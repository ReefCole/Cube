using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsAnimation : MonoBehaviour
{
    Animator LimbAnimator;
    LimbManagement LimbManager;
    public float ExtendSpeed = 1.0f;
    public float RetractSpeed = 1.0f;
    private SfxManager SoundPlayer;
    // Use this for initialization
    void Start ()
    {
        LimbAnimator = this.gameObject.GetComponent<Animator>();
        LimbManager = this.gameObject.GetComponent<LimbManagement>();
        SoundPlayer = this.gameObject.GetComponent<SfxManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        int DownInput = (int)Input.GetAxis("Down");
        int UpInput = (int)Input.GetAxis("Up");
        int LeftInput = (int)Input.GetAxis("Left");
        int RightInput = (int)Input.GetAxis("Right");
        bool ResetInput = Input.GetButtonDown("dir_reset");

        if (ResetInput == true)
        {
            LimbManager.ResetLimbDirections();
        }

        // Control bottom limb
        
        if (DownInput > 0)
        {
            ManipulateLimb("Down", "extend");
        }
        else if (DownInput < 0)
        {
            ManipulateLimb("Down", "retract");
        }
        else if (DownInput == 0)
        {
            ManipulateLimb("Down", "stop");
        }

        // Control top limb
        if (UpInput > 0)
        {
            ManipulateLimb("Up", "extend");

        }
        else if (UpInput < 0)
        {
            ManipulateLimb("Up", "retract");
        }
        else if (UpInput == 0)
        {
            ManipulateLimb("Up", "stop");
        }

        // Control left limb
        if (LeftInput > 0)
        {
            ManipulateLimb("Left", "extend");
        }
        else if (LeftInput < 0)
        {
            ManipulateLimb("Left", "retract");
        }
        else if (LeftInput == 0)
        {
            ManipulateLimb("Left", "stop");
        }

        // Control right limb
        if (RightInput > 0)
        {
            ManipulateLimb("Right", "extend");
        }
        else if (RightInput < 0)
        {
            ManipulateLimb("Right", "retract");
        }
        else if (RightInput == 0)
        {
            ManipulateLimb("Right", "stop");
        }
    }

    public void ManipulateLimb(string aDirection, string aType)
    {
        int layer = LimbManager.GetLimbNumber(aDirection);
        float speed;
        if (aType == "extend")
        {
            speed = ExtendSpeed;
        }
        else if (aType == "retract")
        {
            speed = -RetractSpeed;
        }
        else
        {
            speed = 0;
        }

        float animationTime = LimbAnimator.GetCurrentAnimatorStateInfo(layer - 1).normalizedTime;

        LimbAnimator.SetFloat("Limb" + layer.ToString() + "Speed", speed);

        if (animationTime >= 1.0f && aType == "extend")
        {
            LimbAnimator.Play(LimbAnimator.GetCurrentAnimatorStateInfo(layer - 1).fullPathHash, layer - 1, 1.0f);
            LimbAnimator.SetFloat("Limb" + layer.ToString() + "Speed", 0);
            speed = 0;
        }
        if (animationTime <= 0 && aType == "retract")
        {
            LimbAnimator.Play(LimbAnimator.GetCurrentAnimatorStateInfo(layer - 1).fullPathHash, layer - 1, 0.0f);
            LimbAnimator.SetFloat("Limb" + layer.ToString() + "Speed", 0);
            speed = 0;
        }

        //Debug.Log(speed);
        if (speed != 0f)
        {
            this.gameObject.GetComponent<PhysicsManagement>().ManualCenterOfGravity();
            SoundPlayer.PlaySound(layer - 1, aType);
        }
    }
}
