using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class SliderHPEnemy : MonoBehaviour
{
    public Slider sli;
    public Image Fill;
    public Color clrGreen = Color.green;
    public Color clrRed = Color.red;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        VirusTwo scpTheVirus = GetComponent<VirusTwo>();

        sli.value = scpTheVirus.fHealth;

        if (scpTheVirus.bInfected)
            Fill.color = clrRed;

        if (!scpTheVirus.bInfected)
            Fill.color = clrGreen;
    }
}
