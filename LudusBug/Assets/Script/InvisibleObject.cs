using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleObject : MonoBehaviour {

	void Start () {
        GetComponent<Renderer>().enabled = false;
	}
}
