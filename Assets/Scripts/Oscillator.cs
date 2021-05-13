using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector;
    [SerializeField] [Min(0.01f)] private float period = 5;

    private Vector3 startPosition;

    private const float TAU = 2 * Mathf.PI;

    void Start()
    {
        startPosition = transform.position;
    }

    // rawSineWave is Range[-1,1] so +1 makes it [0-2] and /2 makes it [0-1]
    // The benefit of this is that the startingPosition is now one end of the wave, rather than the middle.
    // rawSineWave (-1 to 1) * movementVector V3(0,5,0) = V3(0,(-5 to 5), 0)
    // sineWave    (0 to 1)  * movementVector V3(0,5,0) = V3(0,(0 to 5), 0)
    void Update()
    {
        float cycles = Time.time / period; 
        float rawSineWave = Mathf.Sin(cycles * TAU);    // Range[-1,1]
        float sineWave = (rawSineWave + 1) / 2;         // Range[0,1]
        Vector3 newPosition = startPosition + (movementVector * sineWave);
        transform.position = newPosition;
    }
}
