using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    private bool godMode;
    // Start is called before the first frame update
    void Start()
    {
        godMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            godMode = !godMode;
            Debug.Log("God Mode = " + godMode);
        }

        if (godMode)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                LevelTransition.LoadNextLevel();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                LevelTransition.ReloadCurrentLevel();
            }
        }
    }

    public bool isGod()
    {
        return godMode;
    }
}
