using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement2 : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float baseSpeed = 5;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = baseSpeed;
    }


    void FixedUpdate()
    {
		if (!Camera.main.GetComponent<Zoom> ().isOnPosition ())
			return;
		float hDir = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;
		float vDir = Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime;

		transform.Translate(new Vector3(hDir,0,vDir));
        rb.velocity = new Vector3(0,0,0);
    }
}
