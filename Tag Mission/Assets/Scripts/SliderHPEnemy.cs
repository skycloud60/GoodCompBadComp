using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class SliderHPEnemy : MonoBehaviour
{
    public Slider sli;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        VirusTwo scpTheVirus = GetComponent<VirusTwo>();
        sli.value = scpTheVirus.fHealth;
    }
}
