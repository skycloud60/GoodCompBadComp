using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // So you can control the speed of the player
    public float fSpeed = 0.0f;

    // So we can access the player's rigidbody
    private Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        // Making a variable to control the rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // FixedUpdate is for physics stuff
    void FixedUpdate()
    {
        // Assigning the horizontal movement via axis grabbing
        float fMoveHorizontal = Input.GetAxis("Horizontal");
        
        // Assigning the vertical movement via axis grabbing
        float fMoveVertical = Input.GetAxis("Vertical");

        // Making a vector 3 so the player can be moved
        Vector3 v3Movement = new Vector3(fMoveHorizontal, 0.0f, fMoveVertical);

        // moving the player's rigidbody via the movement times the speed
        rb.AddForce(v3Movement * fSpeed);
    }
}
