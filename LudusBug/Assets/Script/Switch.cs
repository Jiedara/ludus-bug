using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	[SerializeField]
	bool _state;




	public List<Program> list = new List<Program>();

    public bool State
    {
        get { return _state; }
        set { _state = value; }
    }

    // Use this for initialization
    void Start () {
		refreshMaterial ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void refreshMaterial(){
		gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = State?Color.green:Color.red;
	}

	public void SwitchProgramsState(){
		State = !State;
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
