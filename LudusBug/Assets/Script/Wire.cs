using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wire : MonoBehaviour {

	public Mode mode;

	//public Scene scene;
	public const string folder = "Scene/";
	public string sceneName;
	public int entryPoint = 1;

	public Transform teleportationPoint;

	public enum Mode
	{
		ChangeScene,Teleportation
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("Player")) {
			//SceneManager.SetActiveScene (scene);
			if (mode == Mode.ChangeScene) {
				FindObjectOfType<SceneHandler>().EnterScene(folder + sceneName,entryPoint);
			}
			if (mode == Mode.Teleportation)
				col.gameObject.transform.position = teleportationPoint.transform.position;
		}
	}
}
