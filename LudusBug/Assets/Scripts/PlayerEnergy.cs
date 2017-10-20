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
    float ResistanceCoeff = 5;
    [SerializeField]
    float CurrEnergy;

	// Use this for initialization
	void Start () {
        CurrEnergy = StartEnergy;
        EnergyConsumptionSpeed = BaseEnergyConsumptionSpeed;
	}

    // on trigger enter of fast zone, EnergyConsumptionSpeed *=resistanceCoeff; 
    // on trigger exit of fast zone, ECS = baseECS


    void Update () {
        CurrEnergy = CurrEnergy - Time.deltaTime * EnergyConsumptionSpeed;
	}
}
