using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistor : MonoBehaviour {

	public float resistorResetTime = 10;

	// Use this for initialization
	void Start () {
		ForceField ff = gameObject.transform.GetChild (1).gameObject.AddComponent<ForceField> ();
		gameObject.transform.GetChild (0).gameObject.AddComponent<Component> ().BindForceField(ff,resistorResetTime);
    }

	class Component : MonoBehaviour{
		public IEnumerator disableForceFieldNow;
		public float resistorResetTime = 2;

		ForceField ff;

		void Start () {
			//disableForceFieldNow = disableForceField(resistorResetTime);
		}

		public void BindForceField(ForceField ff,float ResistorResetTime){
			this.ff = ff;
			this.resistorResetTime = resistorResetTime;
		}

		public void OnTriggerEnter(Collider col)
		{
			if (!col.gameObject.CompareTag ("Player"))
				return;
			print ("enter resistor");
			StopAllCoroutines ();
			StartCoroutine(disableForceField(resistorResetTime));
			//col.gameObject.GetComponent<PlayerEnergy> ().setHandicap (false);
		}

		public IEnumerator disableForceField(float wait)
		{
			print ("disableForceField active "+false);
			ff.setActive (false);
			yield return new WaitForSeconds(wait);
			print ("disableForceField active "+true);
			ff.setActive (true);
			yield return null;
		}

		public void OnTriggerExit(Collider col)
		{
			if (!col.gameObject.CompareTag ("Player"))
				return;
			print ("quit resistor");
		}
	}

	class ForceField : MonoBehaviour{
		bool inside = false;
		public void OnTriggerEnter(Collider col)
		{
			if (!col.gameObject.CompareTag ("Player"))
				return;
			print ("enter force field");
			inside = true;
			col.gameObject.GetComponent<PlayerEnergy> ().setHandicap (true);
		}
		public void OnTriggerExit(Collider col)
		{
			if (!col.gameObject.CompareTag ("Player"))
				return;
			print ("quit force field");
			inside = false;
			col.gameObject.GetComponent<PlayerEnergy> ().setHandicap (false);

		}

		public void setActive(bool active){
			if (active && inside) {
				GameObject.FindWithTag ("Player").gameObject.GetComponent<PlayerEnergy> ().setHandicap (true);
			} else {
				GameObject.FindWithTag ("Player").gameObject.GetComponent<PlayerEnergy> ().setHandicap (false);
			}
			gameObject.GetComponent<Renderer> ().enabled = active;
		}
	}
}
