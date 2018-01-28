using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public float fHeightOfHealthBars = 0.0f;

    private Transform trnsSli;
    private Transform trnsEnemy;
	private Transform trnsMesh;

    private bool bLock = true;

    public GameObject goTarget;


    // Use this for initialization
    void Start()
    {
		trnsSli = gameObject.transform.GetChild(0);
		trnsEnemy = gameObject.transform.GetChild(1);
		trnsMesh = gameObject.transform.GetChild(2);
	}
	// Update is called once per frame
	void Update()
	{
		trnsSli.position = trnsEnemy.position;
		trnsMesh.position = trnsSli.position;
		Transform trans = trnsSli;
		trnsSli.position = new Vector3(trans.position.x, fHeightOfHealthBars, trans.position.z);
		Transform trans2 = trnsMesh;
		trnsMesh.position = new Vector3(trans2.position.x, 0f, trans2.position.z);


		if (goTarget)
			trnsSli.LookAt(goTarget.transform);
	}
}
