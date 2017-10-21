using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private KeyCode up = KeyCode.UpArrow;
    [SerializeField]
    private KeyCode down = KeyCode.DownArrow;
    [SerializeField]
    private KeyCode left = KeyCode.LeftArrow;
    [SerializeField]
    private KeyCode right = KeyCode.RightArrow;
    private int onCircuit = 0;
    private GameObject currentCircuit;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKey(up))
        {
            transform.Translate(-1 * speed, 0, 0);
        }
        if (Input.GetKey(down))
        {
            transform.Translate(1 * speed, 0, 0);
        }
        if (Input.GetKey(left))
        {
            transform.Translate(0, 0, -1 * speed);
        }
        if (Input.GetKey(right))
        {
            transform.Translate(0, 0, 1 * speed);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Circuit"))
        {
            onCircuit += 1;
            print("circcuit + :" + onCircuit);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Circuit"))
        {
            onCircuit -= 1;
            print("circcuit - :" + onCircuit);

        }
        if (other.gameObject.CompareTag("Circuit") && onCircuit <= 0)
        {
            if (Input.GetKey(up))
            {
                transform.Translate(1 * speed * 5, 0, 0);
            }
            if (Input.GetKey(down))
            {
                transform.Translate(-1 * speed * 5, 0, 0);
            }
            if (Input.GetKey(left))
            {
                transform.Translate(0, 0, 1 * speed * 5);
            }
            if (Input.GetKey(right))
            {
                transform.Translate(0, 0, -1 * speed * 5);
            }

        }
    }
}
