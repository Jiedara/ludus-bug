using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BG : MonoBehaviour {

    GameObject camera;
    public Texture[] texs;

    void OnEnable()
    {
        SceneManager.sceneLoaded += changeBG;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded += changeBG;
    }

    void changeBG(Scene scene, LoadSceneMode mode)
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        GetComponent<Renderer>().material.mainTexture = texs[Random.Range(0,texs.Length-1)];
    }

    // Use this for initialization
    void Start () {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        if (GameManager.BGSphere == null)
        {
            GameManager.BGSphere = gameObject;
            DontDestroyOnLoad(this);
        }
        else if (GameManager.BGSphere != this)
        {
            Destroy(gameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {
        //transform.position = camera.transform.position;
	}
}
