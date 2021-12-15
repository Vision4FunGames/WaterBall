using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Levels;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 0);
        }
        Levels[PlayerPrefs.GetInt("Level") % 5].SetActive(true);
    }




    public void WinGame()
    {

    }
    public void FailGame()
    {

    }
}
