using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sauvegardeARamasser : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.maxSavesTmp += 1;
            Destroy(gameObject);
        }
    }

}
