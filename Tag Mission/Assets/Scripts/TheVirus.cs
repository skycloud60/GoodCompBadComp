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

            //scpGlobal.lstCharacters.RemoveAt(nEnemy1);

            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {

    }
}