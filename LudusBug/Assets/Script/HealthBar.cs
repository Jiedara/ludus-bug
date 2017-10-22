using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    RectTransform transform;
    PlayerEnergy player;
    float height;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEnergy>();
        transform = GetComponent<RectTransform>();
        height = transform.sizeDelta.y;
    }

    // Update is called once per frame
    void Update()
    {
        //print(player._currEnergy / player.StartEnergy + "  /   "+ height);
        transform.sizeDelta = new Vector2(player._currEnergy / player.StartEnergy * 1850, height);
    }
}
