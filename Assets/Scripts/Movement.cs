using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float thrustFactor;
    [SerializeField]
    private float rotateFactorY;
    [SerializeField]
    private float rotateFactorZ;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            rb.AddRelativeForce(Vector3.up * thrustFactor * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(Vector3.back);
        }
    }

    private void ApplyRotation(Vector3 rotationDirection)
    {
        rb.freezeRotation = true;
        transform.Rotate(rotationDirection * rotateFactorZ * Time.deltaTime);
        rb.freezeRotation = false;
    }

}
