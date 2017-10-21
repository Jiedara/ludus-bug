using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {
    float scroll;
    public float ZoomSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.fieldOfView += scroll*ZoomSpeed;
    }
}
