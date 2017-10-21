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
	}
}
