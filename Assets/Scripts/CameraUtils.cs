using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtils : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float camPosZ;

    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, camPosZ);
    }

    void Update()
    {
        
    }
}
