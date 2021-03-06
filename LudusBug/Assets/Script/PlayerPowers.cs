﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPowers : MonoBehaviour {


    public GameObject[] saves;
    public GameObject save;
    public int CurrSave = 0;
    public bool saveOk = true;
    public GameObject effectingObject;

    public IEnumerator WaitForSaveOkNow;

    void OnDisable() {
        SceneManager.sceneLoaded -= makeSavePointNow;

    }
     void OnEnable()
    {
        SceneManager.sceneLoaded += makeSavePointNow;
    }

    void makeSavePointNow(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine("makeSavePoint");
    }

    IEnumerator makeSavePoint()
    {
        yield return new WaitForSeconds(.1f);
        GameManager.maxSaves = GameManager.maxSavesTmp;
        saves = new GameObject[GameManager.maxSaves + 2];
        save = (GameObject)Instantiate(Resources.Load("Save"), transform.position, transform.rotation);
        save.GetComponent<Save>().SetSave();
        saves[0] = save;
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bobine")
        {
            GetComponent<PlayerMovement2>().speed = GetComponent<PlayerMovement2>().baseSpeed;


        }
    }
    */

    void Update () {
        if (Input.GetButtonDown("Fire1") && GameManager.powerOk  /* && saveOk */)
        {
            if (GameManager.canOverSave && CurrSave + 1 >= GameManager.maxSaves)
            {
                Destroy(saves[1]);
                CurrSave = 0;
            }
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
