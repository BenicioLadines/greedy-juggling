using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    public bool leftHand;
    public float moveForce;
    public float maxVelocity;
    public float passForce;
    Vector3 moveDir;
    Rigidbody rb;
    public Transform otherHand;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(leftHand)
        {
            moveDir = ReadLeftInput();
        }
        else
        {
            moveDir = ReadRightInput();
        }


    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * moveForce);

    }

    Vector3 ReadRightInput()
    {
        Vector3 direction = new Vector3();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += transform.forward;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction -= transform.right;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction -= transform.forward;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += transform.right;
        }
        return direction.normalized;
    }

    Vector3 ReadLeftInput()
    {
        Vector3 direction = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            direction += transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction -= transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += transform.right;
        }
        return direction.normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 difference = otherHand.position - transform.position;
        collision.rigidbody.velocity = new Vector3(0,collision.rigidbody.velocity.y,0) + (new Vector3(difference.x, 0, difference.z) * passForce);
       // collision.rigidbody.AddForce(new Vector3(difference.x, 0, difference.z) * passForce,ForceMode.Impulse);
    }



}
