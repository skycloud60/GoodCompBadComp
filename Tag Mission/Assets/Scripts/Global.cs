using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour
{
    public List<GameObject> lstCharacters;

    [HideInInspector]
    public static int nDeadCounter = 0;
    public static int nPlayerDeaths = 0;
    public static int nEnemyDeaths = 0;
    public int NumberOfEntities = 0;


    // Use this for initialization
    void Start()
    {
        nDeadCounter = 0;
        nPlayerDeaths = 0;
        nEnemyDeaths = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(lstCharacters.Count);

        if (nPlayerDeaths == 1)
        {
            SceneManager.LoadScene("End");
        }
        else if (nDeadCounter >= (NumberOfEntities - 1))
        {
            SceneManager.LoadScene("Win");
        }

    }
}
