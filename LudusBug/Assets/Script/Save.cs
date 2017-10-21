using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour {
    float currentEnergy;
    PlayerEnergy playerEnergy;
    PlayerPowers playerPowers;
    /*
    GameObject[] switches;
    bool[] switchesState;
    */

    private void OnEnable()
    {
        playerEnergy = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEnergy>();
        playerPowers = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPowers>();
        /*
        switches = GameObject.FindGameObjectsWithTag("Switch");
        switchesState = new bool[switches.Length];
        */
        SetSave();
    }

    public void SetSave()
    {
        currentEnergy = playerEnergy.CurrEnergy + GameManager.surplusEnergyOnRespawn;
        
        /*
        for (int i = 0; i < switches.Length; i++)
        {
            switchesState[i] = switches[i].GetComponent<Switch>().State;
        }
        */
    }

    public void GetSave() {
        playerEnergy.transform.position = transform.position;
        playerEnergy.CurrEnergy = currentEnergy;
        print(playerPowers.CurrSave);

        if (playerPowers.CurrSave != 0) {
            print("playerPowers.CurrSave is not 0; it is " + playerPowers.CurrSave);
            playerPowers.saves[playerPowers.CurrSave] = null;
            playerPowers.CurrSave -= 1;
            print(playerPowers.CurrSave);
            Destroy(gameObject);
        }





        /*
        for (int i = 0; i < switches.Length; i++)
        {
            if (switches[i].GetComponent<Switch>().State != switchesState[i]) {
                switches[i].GetComponent<Switch>().SwitchProgramsState();
            }
        }
        */
    }



}
