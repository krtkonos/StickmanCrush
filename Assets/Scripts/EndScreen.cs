using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private float fail = 0;
    [SerializeField] private Text scoreDisplay;
    [SerializeField] private Text failDisplay;
    [SerializeField] private GameObject screen;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private Text finalScore;
    [SerializeField] private GameObject scoreFails;

    public static EndScreen instance;

    private bool _AdClicked = false;

    void Start()
    {
        Time.timeScale = 0;
        SetStartScreen();
        scoreFails.SetActive(false);
        screen.SetActive(false);
    }

    void Update()
    {
        failCounting();
    }
    
    private void failCounting()
    {
        if (FailsScript.failValue >= 5) //If fails = 5, game over
        {
            SetEndScreen();
            ShowEndScreen();
            Time.timeScale = 0; //Pause game
            Stickman.run = 5f; //set stickman fast to normal
            scoreFails.SetActive(false);
        }
        //Hack for development
        if (Input.GetKeyDown("p"))
        {
            FailsScript.failValue += 1;
        }
        if (Input.GetKeyDown("o"))
        {
            ScoreScript.scoreValue += 1;
        }
    }

    private void SetEndScreen() //show end screen
    {
        screen.SetActive(true);
    }

    private void SetStartScreen()
    {
        startScreen.SetActive(true);
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void ShowEndScreen() //Show my score in endscreen
    {
        gameObject.SetActive(true);
        finalScore.text = "Take Downs: " + ScoreScript.scoreValue;

        if (GameRoot._Instance._SavingController.MainData._Highscore < ScoreScript.scoreValue)
        {
            GameRoot._Instance._SavingController.MainData._Highscore = ScoreScript.scoreValue;
            GameRoot._Instance._SavingController.TrySaveData(SaveType.MainData);
        }
    }

    //Buttons
    public void RestartGame()
    {        
        if (ScoreScript.scoreValue > HighScore.bestScore)
        {
            HighScore.bestScore = ScoreScript.scoreValue;
        }

        if (GameRoot._Instance._AdController.IsReadyAnnoying && !_AdClicked)
        {
            _AdClicked = true;
            GameRoot._Instance._AdController.ShowAnnoyingAd(ContinueMainMenu, ContinueMainMenu);
        }
        else
        {
            ContinueMainMenu();
        }
    }

    private void ContinueMainMenu()
    {
        FailsScript.failValue = 0;
        ScoreScript.scoreValue = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame() //Start game button
    {
        Time.timeScale = 1;
        startScreen.SetActive(false);
        scoreFails.SetActive(true);
    }
}
