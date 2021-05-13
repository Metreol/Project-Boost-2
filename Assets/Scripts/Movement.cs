using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float thrustFactor;
    [SerializeField] private float rotateFactorY;
    [SerializeField] private float rotateFactorZ;
    [SerializeField] private AudioClip audioClipThrusters;
    [SerializeField] private ParticleSystem particleSystemThrusters;

    private AudioSource audioSource;
    private Rigidbody rb;

    // PUBLIC METHODS
    public void ThrustersOff()
    {
        if (particleSystemThrusters.isPlaying)
        {
            particleSystemThrusters.Stop();
        }
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // START/UPDATE
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    // THRUST
    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ThrustersOn();
        }
        else
        {
            ThrustersOff();
        }
    }

    private void ThrustersOn()
    {
        if (!particleSystemThrusters.isPlaying)
        {
            particleSystemThrusters.Play();
        }
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClipThrusters);
        }

        rb.AddRelativeForce(Vector3.up * thrustFactor * Time.deltaTime);
    }

    // ROTATION
    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.D))
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
