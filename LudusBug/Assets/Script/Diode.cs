using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diode : MonoBehaviour {

	//[SerializeField]
	Transform output;

	// Use this for initialization
	void Start () {
		output = gameObject.transform.GetChild (0);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("Player")) {
			col.gameObject.transform.position = output.transform.position;
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
        }
    }
}