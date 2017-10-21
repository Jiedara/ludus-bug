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
        saves = new GameObject[GameManager.maxSaves+2];
        save = (GameObject)Instantiate(Resources.Load("Save"), transform.position, transform.rotation);
        save.GetComponent<Save>().SetSave();
        saves[0] = save;
    }

    void Update () {
        if (Input.GetButtonDown("Fire1") && GameManager.powerOk  /* && saveOk */)
        {
            if (GameManager.canOverSave && saves[CurrSave+1] != null)
            {
                    Destroy(saves[CurrSave+1]);

            }
            if (CurrSave+1 <= GameManager.maxSaves)
            {
                CurrSave++;
                save = (GameObject) Instantiate(Resources.Load("Save"), transform.position, transform.rotation);
                save.GetComponent<Save>().SetSave();
                saves[CurrSave] = save;
                if (GameManager.canOverSave && CurrSave >= GameManager.maxSaves) {
                    CurrSave = 1;
                }
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
