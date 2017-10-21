using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void EnterScene(string scene){
		this.EnterScene (scene, 1);
	}
	public void EnterScene(string scene, int entryPoint){
		SceneManager.LoadScene (scene);
		StartCoroutine (TP2EntryPoint (entryPoint));
	}

	IEnumerator TP2EntryPoint(int entryPoint){
		yield return null;
		GameObject player = GameObject.FindGameObjectsWithTag ("Player")[0];
		player.transform.position = GameObject.Find ("EntryPoint" + entryPoint).transform.position;
	}

}
