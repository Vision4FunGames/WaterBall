using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    public GameObject waterPrefab;
    public GameObject[] Levels;
    public GameObject ball;

    void Start()
    {
        ball = FindObjectOfType<BallPlayer>().gameObject;
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 0);
        }
        Levels[PlayerPrefs.GetInt("Level") % 5].SetActive(true);
        StartGame();
    }


    public void StartGame()
    {
        waterPrefab.transform.DOScaleY(0,2f).OnComplete(()=> {
            ball.GetComponent<BallPlayer>().startGame = true;
        });
    }

    public void WinGame()
    {

    }
    public void FailGame()
    {

    }
}
