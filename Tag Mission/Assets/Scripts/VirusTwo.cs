using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusTwo : MonoBehaviour
{
    //colours
    public Material white = null;
    public Material red = null;
    public Material StartingColour = null;

    //[HideInInspector]
    public bool bInfected = false;

    private Material currentColour = null;
    private bool ivin = false;

    public float fHealth = 0.0f;

    public Global gloobal;


    // Use this for initialization
    void Start()
    {
        fHealth = 10;
        //    currentColour = StartingColour;
        //    if (currentColour == red)
        //        bInfected = true;

    }

    private void ResetIvin()
    {
        ivin = false;
    }

    // Update is called once per frame
    void Update()
    {
        Global scpGlobal = GetComponent<Global>();


        if (bInfected)
        {
            fHealth -= 1.0f * Time.deltaTime;
            gameObject.GetComponent<Renderer>().material = red;
        }
        else
            gameObject.GetComponent<Renderer>().material = white;

        if (fHealth <= 0)
        {
            if (gameObject.tag == "Player")
                Global.nPlayerDeaths++;

            else if (gameObject.tag == "Enemy")
                Global.nEnemyDeaths++;

            Global.nDeadCounter++;

            scpGlobal.lstCharacters.RemoveAt(1);

            Destroy(transform.parent.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.GetComponent<VirusTwo>() != null)
        {

            if (bInfected)
            {
                if (col.collider.gameObject.GetComponent<VirusTwo>().ivin != true)
                {
                    ivin = true;
                    Invoke("ResetIvin", 2);
                    //Debug.Log("Hit");
                    col.collider.gameObject.GetComponent<VirusTwo>().bInfected = true;
                    bInfected = false;
                    col.collider.gameObject.GetComponent<Renderer>().material = red;
                    GetComponent<Renderer>().material = white;
                }
            }
            //if (currentColour == white)
            //{
            //    currentColour = red;
            //}


            //else if (currentColour == white && col.gameObject.GetComponent<Renderer>().material == white)
            //    currentColour = white;

            //else
            //    currentColour = white;

        }
    }

}
