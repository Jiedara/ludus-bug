using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capacitor : MonoBehaviour {
		
	[Range(0,100)]
	public float regenerationSpeed;

	PlayerEnergy player;



	void OnTriggerEnter(Collider col){
		if (!col.gameObject.CompareTag ("Player"))
			return;
		print ("player enter in capacitor area");
		player = col.gameObject.GetComponent<PlayerEnergy> ();
	}
	void OnTriggerExit(Collider col){
		if (!col.gameObject.CompareTag ("Player"))
			return;
		print ("player exit capacitor area");
		player = null;
	}

	// Update is called once per frame
	void Update () {
		if (player) {
			player.RestoreEnergy (regenerationSpeed*Time.deltaTime);
		}
	}
}
