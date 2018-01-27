using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController1stPerson : MonoBehaviour
{
    // Min angle the target can tilt the camera downwards
    public float fMinYAngle = 0.0f;

    // Max angle the target can tilt the camera upwards
    public float fMaxYAngle = 0.0f;

    // The target the camera is following
    public Transform target;
    
    // The mouse rotation's current x axis value
    private float fCurrentX = 0.0f;

    // The mouse rotation's current y axis value
    private float fCurrentY = 0.0f;

    // At what speed the target can rotate around the target
    public float fRotateSpeed = 0.0f;


    // Use this for initialization
    void Start()
    {
        // Setting the camera's position to the target's position
        gameObject.transform.rotation = transform.rotation;
    }

    // Update is called once per frame
    private void Update()
    {
        // Assigning the X value from the mouse based on rotation speed
        fCurrentX += Input.GetAxis("Mouse X") * fRotateSpeed;

        // Assigning the Y value from the mouse
        fCurrentY -= Input.GetAxis("Mouse Y") * fRotateSpeed;

        // Clamping the max distance that the target can tilt the camera
        fCurrentY = Mathf.Clamp(fCurrentY, fMinYAngle, fMaxYAngle);
    }

    // LateUpdate is called every frame, if the Behaviour is enabled
    void LateUpdate()
    {
        // Setting up a new vector3 at 0, 0
        Vector3 v3Dir = new Vector3(0, 0, 0);

        // Storing rotation in quaternion from the Euler of the Y and X values
        Quaternion rotation = Quaternion.Euler(fCurrentY, fCurrentX, 0);

        if (target)
        {
            // Rotating the target with the view
            target.rotation = rotation;

            // Rotating the target to sit level so when adding force to move foward or backwards they don't fly into the sky
            target.eulerAngles = new Vector3(0.0f, rotation.eulerAngles.y, 0.0f);

            // The camera's position is equal to the targets position plus the rotation times the direction
            gameObject.transform.rotation = rotation;
        }
    }
}
