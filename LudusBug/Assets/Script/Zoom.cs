﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zoom : MonoBehaviour {
	[SerializeField]
	[Range(25,28)]
    float scroll = 26.5f;

	[SerializeField]
	float scrollSpeed = 1;

	[SerializeField]
	float min = 25;
	[SerializeField]
	float max = 28;

	[SerializeField]
	Transform targetPoint;

	[SerializeField]
	float speed = 1;

	public float quickSpeed = 10;

	private float initSpeed;



    void OnEnable()
    {
        SceneManager.sceneLoaded += GetCameraGoal;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded += GetCameraGoal;
    }

    void GetCameraGoal(Scene scene, LoadSceneMode mode)
    {
        Transform[] transforms = GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<Transform>();
        foreach (Transform trans in transforms)
        {
            if (trans.name == "CameraPoint")
            {
                targetPoint = trans;
            }
        }
    }

    //public float ZoomSpeed;
    // Use this for initialization
    void Start () {
        

            initSpeed = speed;
		if (!Camera.main) {
			Debug.LogWarning ("No Main Camera ! it should have tag MainCamera");
		} else {
			GameObject p = GameObject.FindGameObjectWithTag ("Player");
			gameObject.transform.position = (p.transform.position + new Vector3 (0, 20, -20));
		}
	}

	// Update is called once per frame
	void Update () {
		if (Camera.main) {
			if (isOnPosition ())
				speed = initSpeed;
            else
            {
                speed = quickSpeed;
            }
			scroll += Input.GetAxis ("Mouse ScrollWheel");
			scroll = Mathf.Clamp (scroll, min, max);
			Camera.main.fieldOfView = scroll*scrollSpeed;

			Camera.main.gameObject.transform.position = Vector3.MoveTowards (Camera.main.gameObject.transform.position, targetPoint.transform.position, speed * Time.deltaTime);
		}
    }

	public bool isOnPosition(){
		return Camera.main.transform.position.Equals (targetPoint.position);
	}

	public void setSpeed(float speed){
		this.speed = speed;
	}
    public void resetSpeed()
    {
        speed = initSpeed;
    }

}
