using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool bInfected = false;

    // So you can control the speed of the player
    public float fSpeed = 0.0f;

    // So we can access the player's rigidbody
    private Rigidbody rb;

    // The players direction vector
    private Vector3 v3Dir;


    // Use this for initialization
    void Start()
    {
        // Lock the cursor inside the game
        Cursor.lockState = CursorLockMode.Locked;

        // Making a variable to control the rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Player")
        {
            if (bInfected && col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<Player>().bInfected = true;
                bInfected = false;
            }
            else if (col.gameObject.GetComponent<Player>().bInfected)
            {
                bInfected = true;
                col.gameObject.GetComponent<Player>().bInfected = false;
            }
        }
    }
}
