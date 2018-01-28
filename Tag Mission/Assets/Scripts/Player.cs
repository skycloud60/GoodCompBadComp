using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // So you can control the speed of the player
    public float fSpeed = 0.0f;

    // So we can access the player's rigidbody
    private Rigidbody rb;

    //// The players direction vector
    //Vector3 v3Dir;

    ////Basic acceleration
    //float velocity = 10.0f;
    //float acceleration = 10.0f;
    //float power = 500.0f;

    public float maxSpeed = 1.0f;//Replace with your max speed

    // Use this for initialization
    void Start()
    {
        // Lock the cursor inside the game
        Cursor.lockState = CursorLockMode.Locked;

        // Making a variable to control the rigidbody
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(gameObject.GetComponent<Rigidbody>().velocity, maxSpeed);
    }


    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.y > maxSpeed)
        {
            // Doing a quick dirty hack to access the read-me only variable
            // you cannot access a single axis at a time from rigidBody
            // so we have to make a new vector for it.
            Vector3 v3 = gameObject.GetComponent<Rigidbody>().velocity;
            v3.y = maxSpeed;
            gameObject.GetComponent<Rigidbody>().velocity = v3;
        }

        // Moving the player foward when they press W
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * (fSpeed * Time.deltaTime), ForceMode.VelocityChange);
        }

        // Moving the player backwards when they press S
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * (fSpeed * Time.deltaTime), ForceMode.VelocityChange);
        }

        // Moving the player rightwards when they press D
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * (fSpeed * Time.deltaTime), ForceMode.VelocityChange);
        }

        // Moving the player leftwards when they press A
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * (fSpeed * Time.deltaTime), ForceMode.VelocityChange);
        }


    }
}
