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

	bool _handicap = false;
	public void setHandicap(bool active){
		_handicap = active;
		EnergyConsumptionSpeed = active?EnergyConsumptionSpeed*ResistanceCoeff:BaseEnergyConsumptionSpeed;
		GameManager.powerOk = !active;
	}

    void Update () {
		AddEnergy( - Time.deltaTime * EnergyConsumptionSpeed);
		CalcMaterial ();
		_isSpendingEnergy = Input.GetButton ("Fire2");
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
		} else {
			_energySpend = 0;
		}
	}

	public void AddEnergy(float amount){
		_currEnergy += amount;
		_currEnergy = Mathf.Clamp (_currEnergy, -1, StartEnergy);
		if (_currEnergy <= 0) {
			Die ();
		}
	}

	private void CalcMaterial(){
		Color playerColor;
		//float light = _isSpendingEnergy ? 2 : 0;
		float ratio = _currEnergy / StartEnergy;
		float r = lowestColor.r * (1 - ratio) + highestColor.r * ratio;
		float g = lowestColor.g * (1 - ratio) + highestColor.g * ratio;
		float b = lowestColor.b * (1 - ratio) + highestColor.b * ratio;
		playerColor = new Color (r, g, b);

		Renderer renderer = this.gameObject.GetComponentInChildren<Renderer> ();
		renderer.material.color = playerColor;
		//this.gameObject.transform.GetChild(0).localScale=Vector3.one*(1+Mathf.Log(_energySpend)*3);
	}

    private void Die()
    {
		Camera.main.GetComponent<Zoom> ().setSpeed (Camera.main.GetComponent<Zoom> ().quickSpeed);
        //StopCoroutine(playerPowers.WaitForSaveOkNow);
        //StartCoroutine(playerPowers.WaitForSaveOkNow);
        playerPowers.saves[playerPowers.CurrSave].GetComponent<Save>().GetSave();
    }

}
