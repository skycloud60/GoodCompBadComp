using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class SliderHP : MonoBehaviour
{
    public Slider sli;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TheVirus scpTheVirus = GetComponentInParent<TheVirus>();
        sli.value = scpTheVirus.fHealth;
    }
}
