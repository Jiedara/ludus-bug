using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	[SerializeField]
	bool _state;




	public List<Program> list = new List<Program>();

	// Use this for initialization
	void Start () {
		refreshMaterial ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void refreshMaterial(){
		gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = _state?Color.green:Color.red;
	}

	private void SwitchProgramsState(){
		_state = !_state;
		foreach (Program prog in list) {
			prog.Switch ();
		}
		refreshMaterial ();
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("Player")) {
			SwitchProgramsState ();
		}
	}

}
