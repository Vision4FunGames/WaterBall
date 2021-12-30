using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSc : MonoBehaviour
{
    public GameObject waterobj, camurobj, dikenobj;

    public GameObject _closeTutoBtn;
    public GameObject _firstTutorial;
    public GameObject _waterTutorial;
    public GameObject _dikenTutorial;
    public GameObject _camurTutorial;
    void Start()
    {
        if (PlayerPrefs.HasKey("tuto"))
        {
            waterobj.SetActive(false);
            camurobj.SetActive(false);
            dikenobj.SetActive(false);
            
        }
    }

    void Update()
    {

    }
    public void CamurTutorial()
    {
        Time.timeScale = 0;
        _camurTutorial.SetActive(true);
        _closeTutoBtn.SetActive(true);
        PlayerPrefs.SetInt("tuto", 0);
    }
    public void FirstTutorial()
    {
        Time.timeScale = 0;
        _firstTutorial.SetActive(true);
        _closeTutoBtn.SetActive(true);
        PlayerPrefs.SetInt("tuto", 0);
    }
    public void WaterTutorial()
    {
        Time.timeScale = 0;
        _waterTutorial.SetActive(true);
        _closeTutoBtn.SetActive(true);
        PlayerPrefs.SetInt("tuto", 0);
    }
    public void DikenTutorial()
    {
        Time.timeScale = 0;
        _dikenTutorial.SetActive(true);
        _closeTutoBtn.SetActive(true);
        PlayerPrefs.SetInt("tuto", 0);
    }
    public void closeTuto()
    {
        Time.timeScale = 1;
        _dikenTutorial.SetActive(false);
        _firstTutorial.SetActive(false);
        _waterTutorial.SetActive(false);
        _camurTutorial.SetActive(false);
    }
}
