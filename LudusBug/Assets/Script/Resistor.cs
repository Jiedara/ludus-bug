using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistor : MonoBehaviour {
    Collider trigger;
    Renderer rd;
    float resistorResetTime;
    IEnumerator disableForceFieldNow;

	// Use this for initialization
	void Start () {
        trigger = GetComponentsInChildren<Collider>()[1];
        rd = GetComponentsInChildren<Renderer>()[1];
        disableForceFieldNow = disableForceField(resistorResetTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(disableForceFieldNow);
        }
    }

    IEnumerator disableForceField(float wait)
    {
        rd.enabled = false;
        trigger.enabled = false;
        yield return new WaitForSeconds(wait);
        rd.enabled = true;
        trigger.enabled = true;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
