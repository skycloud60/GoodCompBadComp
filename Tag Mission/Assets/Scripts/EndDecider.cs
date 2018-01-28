using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDecider : MonoBehaviour
{
    Transform win;
    Transform lose;


    // Use this for initialization
    void Start()
    {
        lose = gameObject.transform.GetChild(0);
        win = gameObject.transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
            win.transform.position = new Vector3(0, 0, 0);

        if (false)
            lose.transform.position = new Vector3(0, 0, 0);
    }
}
