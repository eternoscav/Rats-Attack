using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

    void Awake()
    {
        if (Screen.currentResolution.width > 960)
        {
            Application.LoadLevel(1);
        }
        if (Screen.currentResolution.width <= 960)
        {
            Application.LoadLevel(0);
        }
    }


}
