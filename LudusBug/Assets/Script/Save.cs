using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour {
    float currentEnergy;
    PlayerEnergy playerScript;

	// Use this for initialization
	void Start () {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEnergy>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetSave()
    {
        //currentEnergy = playerScript.currentEnergy;


    }


}
