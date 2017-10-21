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
    
    public float _currEnergy;
    PlayerPowers playerPowers;

    private AudioSource audioSource;
    public AudioClip respawn;
    public AudioClip perteEnergie;

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
    void Awake () {
    // Use this for initialization
        _currEnergy = StartEnergy;
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
        _currEnergy = _currEnergy - Time.deltaTime * EnergyConsumptionSpeed;
		CalcMaterial ();
		_isSpendingEnergy = Input.GetButton ("Fire1");
        if (_currEnergy <= 0)
        {
            Die();
        }
		if (_isSpendingEnergy) {
			if (_energySpend <= 0)
				_energySpend = 1;
			float amount = _energySpend * overvoltageSpeed * Time.deltaTime;
			AddEnergy (-amount);
			_energySpend += amount;
		}
	}

	public void AddEnergy(float amount){
		_currEnergy += amount;
		_currEnergy = Mathf.Clamp (_currEnergy, -1, StartEnergy);
	}

	private void CalcMaterial(){
		Color playerColor;
		if (_isSpendingEnergy) {
			playerColor = Color.red;
		} else {
			float ratio = _currEnergy / StartEnergy;
			float r = lowestColor.r * (1 - ratio) + highestColor.r * ratio;
			float g = lowestColor.g * (1 - ratio) + highestColor.g * ratio;
			float b = lowestColor.b * (1 - ratio) + highestColor.b * ratio;
			float a = lowestColor.a * (1 - ratio) + highestColor.a * ratio;
			playerColor = new Color (r, g, b, a);
		}

		this.gameObject.GetComponentInChildren<Renderer>().material.color = playerColor;
	}

    private void Die()
    {
        //StopCoroutine(playerPowers.WaitForSaveOkNow);
        //StartCoroutine(playerPowers.WaitForSaveOkNow);
        print(playerPowers.CurrSave);
        playerPowers.saves[playerPowers.CurrSave].GetComponent<Save>().GetSave();
        audioSource.clip = respawn;
        audioSource.Play();

    }

}
