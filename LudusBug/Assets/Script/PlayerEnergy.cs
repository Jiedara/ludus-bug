using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour {

	[SerializeField]
	float overvoltageSpeed = 1;

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

	private bool _isSpendingEnergy;
	private float _energySpend;

	public bool isSpendingEnergy(){
		return _isSpendingEnergy;
	}
	public float getEnergySpend(){
		return _energySpend;
	}


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

		_isSpendingEnergy = Input.GetButton ("Fire1");
		if (_isSpendingEnergy) {
			if (_energySpend <= 0)
				_energySpend = 1;
			float amount = _energySpend * overvoltageSpeed * Time.deltaTime;
			AddEnergy (-amount);
			_energySpend += amount;
		}
	}

	public void AddEnergy(float amount){
		CurrEnergy += amount;
		CurrEnergy = Mathf.Clamp (CurrEnergy, -1, StartEnergy);
	}

	private void CalcMaterial(){
		Color playerColor;
		if (_isSpendingEnergy) {
			playerColor = Color.red;
		} else {
			float ratio = CurrEnergy / StartEnergy;
			float r = lowestColor.r * (1 - ratio) + highestColor.r * ratio;
			float g = lowestColor.g * (1 - ratio) + highestColor.g * ratio;
			float b = lowestColor.b * (1 - ratio) + highestColor.b * ratio;
			float a = lowestColor.a * (1 - ratio) + highestColor.a * ratio;
			playerColor = new Color (r, g, b, a);
		}

		this.gameObject.GetComponentInChildren<Renderer>().material.color = playerColor;
	}
}
