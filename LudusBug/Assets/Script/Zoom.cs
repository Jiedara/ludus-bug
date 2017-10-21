using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //public float ZoomSpeed;
	// Use this for initialization
	void Start () {
		if (!Camera.main) {
			Debug.LogWarning ("No Main Camera ! it should have tag MainCamera");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main) {

			scroll += Input.GetAxis ("Mouse ScrollWheel");
			scroll = Mathf.Clamp (scroll, min, max);
			Camera.main.fieldOfView = scroll*scrollSpeed;

			Camera.main.gameObject.transform.position = Vector3.MoveTowards (Camera.main.gameObject.transform.position, targetPoint.transform.position, speed * Time.deltaTime);
		}
    }
}
