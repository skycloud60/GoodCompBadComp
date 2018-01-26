using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // The player gameobject accessor
    public GameObject goPlayer;

    // The offset vector to keep the camera following the player
    private Vector3 v3Offset;

    // Use this for initialization
    void Start()
    {
        // Set the offset to be the current camera position away from the player 
        v3Offset = transform.position - goPlayer.transform.position;
    }

    // LateUpdate is called every frame, if the Behaviour is enabled
    void LateUpdate()
    {
        // Move the camera with the player
        transform.position = goPlayer.transform.position + v3Offset;
    }
}
