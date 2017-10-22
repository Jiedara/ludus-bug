using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker : MonoBehaviour {
    Renderer rd;
    IEnumerator changeGoalNow;
    float goal;
    float changeIntensity;
    public float steps = .3f;
    float change;
    float BaseScale;
    Vector2 wait = new Vector2(-.1f,.1f);

	// Use this for initialization
	void Start () {
        rd = GetComponent<Renderer>();
        //changeGoalNow = changeGoal(wait.x, wait.y);
        change = transform.localScale.x;
        BaseScale = transform.localScale.x;

    }
	
    /*
    IEnumerator changeGoal(float waitMin, float waitMax)
    {
        goal = Random.Range(0, changeIntensity);
        yield return new WaitForSeconds(Random.Range(waitMin, waitMax));
        StartCoroutine(changeGoalNow);
    }
    */


	// Update is called once per frame
	void Update () {
        //change = Mathf.Lerp(transform.localScale.x, goal, goal-change/20);
        change = transform.localScale.x + Random.Range(wait.x, wait.y);
        change = Mathf.Clamp(change, BaseScale- steps, BaseScale +steps);
        transform.localScale = new Vector3(change, change, change);
        rd.material.SetColor("_EmissionColor", new Color(1+change, 1+change, 1+change, 1));
	}
}
