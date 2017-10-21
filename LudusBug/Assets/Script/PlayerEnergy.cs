using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour {
    [SerializeField]
    float EnergyConsumptionSpeed;
    float BaseEnergyConsumptionSpeed = 1;
    [SerializeField]
    float StartEnergy = 500;
    [SerializeField]
    float ResistanceCoeff = 25;
    [SerializeField]
    float CurrEnergy;

	[SerializeField]
	Color lowestColor;
	[SerializeField]
	Color highestColor;

	// Use this for initialization
	void Start () {
        CurrEnergy = StartEnergy;
        EnergyConsumptionSpeed = BaseEnergyConsumptionSpeed;
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Resistance")
        {
            EnergyConsumptionSpeed *= ResistanceCoeff;
            PlayerPowers.powerOk = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Resistance")
        {
            EnergyConsumptionSpeed = BaseEnergyConsumptionSpeed;
            PlayerPowers.powerOk = true;
        }
    }

    void Update () {
        CurrEnergy = CurrEnergy - Time.deltaTime * EnergyConsumptionSpeed;
		CalcMaterial ();
	}

	public void RestoreEnergy(float amount){
		CurrEnergy += amount;
		CurrEnergy = Mathf.Clamp (CurrEnergy, -1, StartEnergy);
	}

	private void CalcMaterial(){
		float ratio = CurrEnergy / StartEnergy;
		float r = lowestColor.r * (1 - ratio) + highestColor.r * ratio;
		float g = lowestColor.g * (1 - ratio) + highestColor.g * ratio;
		float b = lowestColor.b * (1 - ratio) + highestColor.b * ratio;
		float a = lowestColor.a * (1 - ratio) + highestColor.a * ratio;
		Color playerColor = new Color(r,g,b,a);

		this.gameObject.GetComponentInChildren<Renderer>().material.SetColor("_Color",playerColor);
	}
}
