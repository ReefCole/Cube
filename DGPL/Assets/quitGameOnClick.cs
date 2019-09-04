using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitGameOnClick : MonoBehaviour {

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }


}
