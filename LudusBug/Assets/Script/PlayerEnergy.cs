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
    float _currEnergy;
    PlayerPowers playerPowers;



    [SerializeField]
	Color lowestColor;
	[SerializeField]
	Color highestColor;

    public float CurrEnergy
    {
        get {return _currEnergy;}
        set { _currEnergy = value;}
    }

    // Use this for initialization
    void Awake () {
        CurrEnergy = StartEnergy;
        EnergyConsumptionSpeed = BaseEnergyConsumptionSpeed;
        playerPowers = GetComponent<PlayerPowers>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Resistance")
        {
            EnergyConsumptionSpeed *= ResistanceCoeff;
            GameManager.powerOk = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Resistance")
        {
            EnergyConsumptionSpeed = BaseEnergyConsumptionSpeed;
            GameManager.powerOk = true;
        }
    }

    void Update () {
        CurrEnergy = CurrEnergy - Time.deltaTime * EnergyConsumptionSpeed;
		CalcMaterial ();
        if (CurrEnergy <= 0)
        {
            Die();

        }
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
		this.gameObject.GetComponentInChildren<Renderer>().material.color = playerColor;
	}

    private void Die()
    {
        //StopCoroutine(playerPowers.WaitForSaveOkNow);
        //StartCoroutine(playerPowers.WaitForSaveOkNow);
        print("dying: "+ playerPowers.CurrSave);
        playerPowers.saves[playerPowers.CurrSave].GetComponent<Save>().GetSave();


    }

}
