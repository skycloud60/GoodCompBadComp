using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController3rdPerson : MonoBehaviour
{
    // Min angle the target can tilt the camera downwards
    public float fMinYAngle = 0.0f;

    // Max angle the target can tilt the camera upwards
    public float fMaxYAngle = 0.0f;

    // The target the camera is following
    public Transform target;

    // The camera's position
    public Transform tCamTransform;

    // How far away from the target the camera will spawn
    public float fDistanceFromPlayer = 10.0f;
    
    // The mouse rotation's current x axis value
    private float fCurrentX = 0.0f;

    // The mouse rotation's current y axis value
    private float fCurrentY = 0.0f;

    // At what speed the target can rotate around the target
    public float fRotateSpeed = 0.0f;

    // Use this for initialization
    void Start()
    {
        // Setting the cameras position to the target's position
        tCamTransform = transform;
    }

    // Update is called once per frame
        private void Update()
    {
        // Assigning the X value from the mouse based on rotation speed
        fCurrentX += Input.GetAxis("Mouse X") * fRotateSpeed;

        // Assigning the Y value from the mouse
        fCurrentY -= Input.GetAxis("Mouse Y");

        // Clamping the max distance that the target can tilt the camera
        fCurrentY = Mathf.Clamp(fCurrentY, fMinYAngle, fMaxYAngle);
    }

    // LateUpdate is called every frame, if the Behaviour is enabled
    void LateUpdate()
    {
        // Setting up a new vector3 at 0, 0, and the distance previously set away from the target
        Vector3 v3Dir = new Vector3(0, 0, -fDistanceFromPlayer);

        // Storing rotation in quaternion from the Euler of the Y and X values
        Quaternion rotation = Quaternion.Euler(fCurrentY, fCurrentX, 0);

        // Rotating the target with the view
        target.rotation = rotation;

        // Rotating the target to sit level so when adding force to move foward or backwards they don't fly into the sky
        target.eulerAngles = new Vector3(0.0f, rotation.eulerAngles.y, 0.0f);

        // The camera's position is equal to the targets position plus the rotation times the direction
        tCamTransform.position = target.position + rotation * v3Dir;

        // Make the camera look at the target
        tCamTransform.LookAt(target.position);
    }
}
