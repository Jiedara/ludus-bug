using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowers : MonoBehaviour {


    public GameObject[] saves;
    public GameObject save;
    public int CurrSave = 0;
    public bool saveOk = true;

    public IEnumerator WaitForSaveOkNow;



    private void Start()
    {
        WaitForSaveOkNow = WaitForSaveOk(GameManager.WaitTimeAfterRespawnToSaveAgain);
        saves = new GameObject[GameManager.maxSaves];
    }

    void Update () {
        if (Input.GetButtonDown("Fire1") && GameManager.powerOk  /* && saveOk */)
        {
            if (GameManager.canOverSave) {
                if (CurrSave >= GameManager.maxSaves){
                    CurrSave = 0;
                }
                if (saves[CurrSave] != null)
                {
                    Destroy(saves[CurrSave]);
                }

            }
            if (CurrSave < GameManager.maxSaves)
            {
                save = (GameObject) Instantiate(Resources.Load("Save"), transform.position, transform.rotation);
                save.GetComponent<Save>().SetSave();
                saves[CurrSave] = save;
                CurrSave++;
            }
        }
	}


     IEnumerator WaitForSaveOk(float wait)
    {
        saveOk = false;
        yield return new WaitForSeconds(wait);
        saveOk = true;
    }

}
