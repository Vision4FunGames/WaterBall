using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public int scoreValue;
    public GameObject waterPrefab;
    public GameObject[] Levels;
    public GameObject ball;
    public GameObject winP, loseP;
    public static GameManager instance;

    void Start()
    {
        instance = this;
       
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 0);
        }
        Levels[PlayerPrefs.GetInt("Level") % 5].SetActive(true);
        ball = FindObjectOfType<BallPlayer>().gameObject;
        StartGame();
    }
    public void StartGame()
    {
        waterPrefab.transform.DOScaleY(0, 2f).OnComplete(() =>
        {
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
