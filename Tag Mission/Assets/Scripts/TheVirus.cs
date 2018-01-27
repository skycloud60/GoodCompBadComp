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

    //private bool bCantInfect = true;
    //public float fCantInfectTime = 0.0f;
    //private float fCantInfectCount = 0.0f;

    private int nEnemy1 = 0;
    private int nEnemy2 = 1;
    private int nEnemy3 = 2;
    private int nEnemy4 = 3;
    private int nEnemy5 = 4;

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
            Global scpGlobal = GetComponent<Global>();

            scpGlobal.lstCharacters.RemoveAt(nEnemy1);

            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {

        //    if (bCantInfect)
        //    {
        //        if (col.gameObject.tag == "Player")
        //        {
        //            bCantInfect = false;

        //            if (bInfected)
        //            {
        //                bInfected = false;

        //                col.gameObject.GetComponent<TheVirus>().bInfected = true;
        //            }

        //            if (!bInfected)
        //            {
        //                bInfected = true;

        //                col.gameObject.GetComponent<TheVirus>().bInfected = false;
        //            }
        //        }

        //        if (col.gameObject.tag == "Enemy")
        //        {
        //            bCantInfect = false;

        //            if (bInfected)
        //            {
        //                bInfected = false;

        //                col.gameObject.GetComponent<TheVirus>().bInfected = true;
        //            }

        //            if (!bInfected)
        //            {
        //                bInfected = true;

        //                col.gameObject.GetComponent<TheVirus>().bInfected = false;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (fCantInfectCount > fCantInfectTime)
        //        {
        //            fCantInfectCount += Time.deltaTime;
        //        }
        //        else
        //        {
        //            bCantInfect = true;
        //            fCantInfectCount = 0.0f;
        //        }
        //    }
        //}

        //    if (col.gameObject.tag == "Player")
        //    {
        //        // Collided with character was touched, they are infected
        //        if (col.gameObject.GetComponent<TheVirus>().bInfected)
        //        {
        //            // Current character becomes infected
        //            bInfected = true;

        //            // Collided with character loses their infection
        //            col.gameObject.GetComponent<TheVirus>().bInfected = false;
        //        }
        //        else
        //        {
        //            // Current character loses the infection
        //            bInfected = false;

        //            // Collided with character gains the infection
        //            col.gameObject.GetComponent<TheVirus>().bInfected = true;
        //        }
        //    }
    }
}