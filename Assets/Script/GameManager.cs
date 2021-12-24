using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public int scoreValue;
    public GameObject waterPrefab;
    public GameObject[] Levels;
    public GameObject ball;
    public GameObject winP, loseP;
    public static GameManager instance;

    void Awake()
    {
        instance = this;
       
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 0);
        }
        //Levels[PlayerPrefs.GetInt("Level") % 5].SetActive(true);
        ball = FindObjectOfType<BallPlayer>().gameObject;
      
    }
    private void Start()
    {
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
        winP.SetActive(true);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
    }
    public void FailGame()
    {

    }
    public void nextLevel()
    {
        SceneManager.LoadScene("MainGame");
    }
}
