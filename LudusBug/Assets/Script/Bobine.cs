using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobine : MonoBehaviour {
    PlayerMovement2 playerMovement;
    float acceleration = 5;
    float accelerationDuree = 2;
    IEnumerator acceleratingNow;
    private bool isAccelerating = false;

	void Start () {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement2>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && isAccelerating)
        {
            isAccelerating = false;
            playerMovement.speed = playerMovement.baseSpeed;
            StopCoroutine(acceleratingNow);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            acceleratingNow = accelerating(accelerationDuree);
            StartCoroutine(acceleratingNow);
        }
    }



    IEnumerator accelerating(float wait)
    {
        isAccelerating = true;
        playerMovement.speed *= acceleration;
        yield return new WaitForSeconds(wait);
        
            playerMovement.speed = playerMovement.baseSpeed;
            isAccelerating = false;
        }
    
}
