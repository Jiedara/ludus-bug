using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour {

	bool _open;

	[SerializeField]
	Color32 color = Color.blue;

	public bool Open {
		get{ return _open; }
		set{
			_open = value;
			this.gameObject.SetActive (!value);
		}
	}

	public void Switch() {
        if (PlayerPowers.powerOk) {
            Open = !Open;
        }
    }

	void Start(){
		gameObject.GetComponent<Renderer>().material.color = color;
	}
		
}
