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
        // Player infection logic
        if (col.gameObject.tag == "Player")
        {
            // If the player was touched and they are infected
            if (col.gameObject.GetComponent<TheVirus>().bInfected)
            {
                // Enemy become infected
                bInfected = true;

                // Player loses their infection
                col.gameObject.GetComponent<TheVirus>().bInfected = false;
            }
        }

        // Enemy infection logic
        if (col.gameObject.tag == "Enemy")
        {
            if (col.gameObject.GetComponent<TheVirus>().bInfected)
            {
                // Player becomes infected
                bInfected = true;

                // Enemy loses their infection
                col.gameObject.GetComponent<TheVirus>().bInfected = false;
            }
        }
    }
}
