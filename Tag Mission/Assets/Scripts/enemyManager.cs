using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public float fHeightOfHealthBars = 0.0f;
    private Transform trnsSli;
    private Transform trnsEnemy;
    // Use this for initialization
    void Start()
    {
        trnsSli = gameObject.transform.GetChild(0);
        trnsEnemy = gameObject.transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (trnsSli)
        {
            trnsSli.position = trnsEnemy.position;
            Transform trans = trnsSli;
            trnsSli.position = new Vector3(trans.position.x, fHeightOfHealthBars, trans.position.z);
        }
    }
}
