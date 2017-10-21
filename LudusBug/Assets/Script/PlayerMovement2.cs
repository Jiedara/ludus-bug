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
		float hDir = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;
		float vDir = Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime;

		transform.Translate(new Vector3(hDir,0,vDir));
    }
}
