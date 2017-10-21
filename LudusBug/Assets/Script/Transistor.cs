using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transistor : MonoBehaviour {

    public Transform TPPoint;
    public float cost;

    private PlayerEnergy player;
    private Renderer[] rd;
    private Collider[] cols;
    private bool casse = false;

    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        player = col.gameObject.GetComponent<PlayerEnergy>();
    }
    void OnTriggerExit(Collider col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        player = null;
    }
    // Use this for initialization
    void Start()
    {
        rd = GetComponentsInChildren<Renderer>();
        cols = GetComponentsInChildren<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
            return;
        if (player.isSpendingEnergy() && !casse)
        {
            if (player.getEnergySpend() >= cost)
            {
                foreach(Renderer rend in rd)
                {
                    rend.enabled = !rend.enabled;
                }
                foreach (Collider col in cols) {
                    col.enabled = false;
                }
                casse = true;
            }
        }
    }
}
