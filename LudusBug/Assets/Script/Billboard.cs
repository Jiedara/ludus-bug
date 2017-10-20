using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {
    private GameObject camera;

	// Use this for initialization
	void Start () {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(transform.position + camera.transform.rotation * Vector3.forward,
        camera.transform.rotation * Vector3.up);
    }
}
