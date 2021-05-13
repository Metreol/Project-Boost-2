using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Crash : MonoBehaviour
{
    [SerializeField] private float crashDelayInSecs = 2f;
    [SerializeField] private float levelCompleteDelayInSecs = 2f;
    [SerializeField] private AudioClip audioClipCrash;
    [SerializeField] private AudioClip audioClipWin;
    [SerializeField] private ParticleSystem particleSystemCrash;
    [SerializeField] private ParticleSystem particleSystemWin;

    private AudioSource audioSource;
    private Cheat cheat;

    private bool isAlive;
    private bool godMode;

    void Start()
    {
        isAlive = true;
        audioSource = GetComponent<AudioSource>();
        cheat = GetComponent<Cheat>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isAlive && !cheat.isGod())
        {
            switch (collision.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("Safe Zone");
                    break;

                case "Finish":
                    Debug.Log("Level Complete - Starting Next Level");
                    LevelComplete();
                    break;

                default:
                    Debug.Log("Level Failed - Restarting Level");
                    Crashed();
                    break;
            }
        }
    }

    private void Crashed()
    {
        particleSystemCrash.Play();
        isAlive = false;
        DisableMovement();
        audioSource.PlayOneShot(audioClipCrash);
        Invoke(nameof(ReloadCurrentLevel), crashDelayInSecs);
    }

    private void LevelComplete()
    {
        particleSystemWin.Play();
        isAlive = false;
        DisableMovement();
        audioSource.PlayOneShot(audioClipWin);
        Invoke(nameof(LoadNextLevel), levelCompleteDelayInSecs);
    }

    private void LoadNextLevel()
    {
        LevelTransition.LoadNextLevel();
    }

    private void ReloadCurrentLevel()
    {
        LevelTransition.ReloadCurrentLevel();
    }

    private void DisableMovement()
    {
        Movement movement = GetComponent<Movement>();
        movement.ThrustersOff();
        movement.enabled = false;
    }

}
