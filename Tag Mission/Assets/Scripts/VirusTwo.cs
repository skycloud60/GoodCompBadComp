using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusTwo : MonoBehaviour
{
    //colours
    public Material white = null;
    public Material red = null;
    public Material StartingColour = null;

    [SerializeField]
    private bool bInfected = false;

    private Material currentColour = null;
    private bool ivin = false;


    // Use this for initialization
    void Start()
    {
        currentColour = StartingColour;
        if (currentColour == red)
            bInfected = true;

    }

    private void ResetIvin()
    {
        ivin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(bInfected)
            gameObject.GetComponent<Renderer>().material = red;
        else
            gameObject.GetComponent<Renderer>().material = white;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.GetComponent<VirusTwo>() != null)
        {

            if (bInfected)
            {
                if (col.collider.gameObject.GetComponent<VirusTwo>().ivin != true) {
                    ivin = true;
                    Invoke("ResetIvin", 2);
                    Debug.Log("Hit");
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
