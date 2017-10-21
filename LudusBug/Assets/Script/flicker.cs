using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker : MonoBehaviour {
    Renderer rd;
    IEnumerator changeGoalNow;
    float goal;
    float changeIntensity;
    float steps = .1f;
    float change;
    Vector2 wait = new Vector2(.1f,1);

	// Use this for initialization
	void Start () {
        rd = GetComponent<Renderer>();
        changeGoalNow = changeGoal(wait.x, wait.y);
        change = transform.localScale.x;
	}
	
    IEnumerator changeGoal(float waitMin, float waitMax)
    {
        goal = Random.Range(0, changeIntensity);
        yield return new WaitForSeconds(Random.Range(waitMin, waitMax));
        StartCoroutine(changeGoalNow);
    }



	// Update is called once per frame
	void Update () {
        change = Mathf.Lerp(transform.localScale.x, goal, goal-change/20);
        transform.localScale += new Vector3(change,change,change);
        rd.material.SetColor("_EmissionColor", new Color(change, change, change, 1));
	}
}
