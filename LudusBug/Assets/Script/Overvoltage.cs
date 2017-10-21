using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overvoltage : MonoBehaviour {

	public Transform TPPoint;
	public float cost;

	private PlayerEnergy player;

	void OnTriggerEnter(Collider col){
		if(!col.gameObject.CompareTag("Player"))return;
		player = col.gameObject.GetComponent<PlayerEnergy> ();
	}
	void OnTriggerExit(Collider col){
		if(!col.gameObject.CompareTag("Player"))return;
		player = null;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!player)
			return;
		if (player.isSpendingEnergy()) {
			if (player.getEnergySpend() >= cost) {
				player.gameObject.transform.position = TPPoint.position;
			}
		}
	}
}
