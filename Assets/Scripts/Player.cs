using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 movementVector;
    public float speed = 1.5f;
    private Rigidbody body;
    private Animator animator;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }
    private void Update()
    {
        CalculateMovement();

        if(movementVector!= Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementVector), 0.25f);
        }
        animator.SetBool("Walking", movementVector != Vector3.zero);
    }

    void CalculateMovement()
    {
        movementVector = new Vector3(
            Input.GetAxis("Horizontal"),
            body.velocity.y,
            Input.GetAxis("Vertical"));

        body.velocity = new Vector3(
            movementVector.x * speed,
            movementVector.y,
            movementVector.z * speed
            );

    }
}
