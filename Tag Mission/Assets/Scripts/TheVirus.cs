using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheVirus : MonoBehaviour
{
    // Health
    public float fHealth = 0.0f;

    // Infected or not
    public bool bInfected = false;

    // How fast the player loses health when infected
    public float fSpeedOfHPDeduction = 0.0f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fHealth < 5.0f)

        // If the player is infected deduct health
        if (bInfected)
        {
            fHealth -= 1.0f * (Time.deltaTime * fSpeedOfHPDeduction);
        }

        // If the player is dead kill them
        if (fHealth < 0.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            // Collided with character was touched, they are infected
            if (col.gameObject.GetComponent<TheVirus>().bInfected)
            {
                // Current character becomes infected
                bInfected = true;

                // Collided with character loses their infection
                col.gameObject.GetComponent<TheVirus>().bInfected = false;
            }
            else
            {
                // Current character loses the infection
                bInfected = false;

                // Collided with character gains the infection
                col.gameObject.GetComponent<TheVirus>().bInfected = true;
            }
        }
    }
}
