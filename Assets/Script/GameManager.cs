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
    bool isonce;
    void Awake()
    {
        instance = this;
        print(PlayerPrefs.GetInt("Level"));
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 0);
        }
        Levels[PlayerPrefs.GetInt("Level") % 5].SetActive(true);
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
            FindObjectOfType<TutorialSc>()._closeTutoBtn.SetActive(true);
            ball.GetComponent<BallPlayer>().startGame = true;
            FindObjectOfType<TutorialSc>()._firstTutorial.SetActive(true);
            waterPrefab.GetComponent<AudioSource>().Stop();
            Time.timeScale = 0;
        });
    }
    public void WinGame()
    {
        if (!isonce)
        {
            winP.SetActive(true);
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            isonce = true;
        }

    }
    public void FailGame()
    {
        loseP.SetActive(true);
    }
    public void nextLevel()
    {
        SceneManager.LoadScene("MainGame");
    }
}
