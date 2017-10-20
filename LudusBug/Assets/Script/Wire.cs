using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wire : MonoBehaviour {

	//public Scene scene;
	const string folder = "Scene/";
	public string sceneName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("Player")) {
			//SceneManager.SetActiveScene (scene);
			SceneManager.LoadScene(folder+sceneName);
		}
	}
}
