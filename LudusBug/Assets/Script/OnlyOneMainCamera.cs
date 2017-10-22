using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyOneMainCamera : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        if (GameManager.MainCamera == null)
        {
            GameManager.MainCamera = gameObject;
            DontDestroyOnLoad(this);
        }
        else if (GameManager.MainCamera != this)
        {
            Destroy(gameObject);
        }

    }
}
