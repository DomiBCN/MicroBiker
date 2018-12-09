﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [Header("Panels")]
    public GameObject startPanel;
    public GameObject bestScorePanel;
    public GameObject tutorialPanel;
    public GameObject finalScore;

    [Header("HUD")]
    public TextMeshProUGUI timer;
    public TextMeshProUGUI bugCounter;
    public TextMeshProUGUI coinsCounter;
    
    [HideInInspector] public static GameManager instance;
    [HideInInspector] public Level levelData;
    [HideInInspector] public double timerValue;
    [HideInInspector] public int bugsKilled = 0;
    [HideInInspector] public int coinsCollected = 0;

    int currentLevelId;
    bool gameStarted;
    float startTime;
    

    private void Awake()
    {
        instance = this;
        Time.timeScale = 0;
        currentLevelId = PlayerPrefs.GetInt("CurrentLevel", 1);
        levelData = GamePersister.GetLevelById(currentLevelId);
    }

    // Use this for initialization
    void Start () {
        
        if(levelData.MaxScore != 0)
        {
            bestScorePanel.SetActive(true);
        }
        else
        {
            startPanel.SetActive(true);
            tutorialPanel.SetActive(true);
        }
        UpdateCounter(bugCounter, bugsKilled, levelData.LevelGoals.Bugs);
        UpdateCounter(coinsCounter, coinsCollected, levelData.LevelGoals.Coins);
    }
	
	// Update is called once per frame
	void Update () {
		if(gameStarted)
        {
            timerValue = Math.Round((Time.time - startTime), 2);
            timer.text = timerValue.ToString("##.##") + " s";
        }
	}

    public void StartGame()
    {
        if(!gameStarted)
        {
            gameStarted = true;
            startTime = Time.time;

        }
        else
        {
            
        }
        Time.timeScale = 1;
    }

    public void FinshLineReached()
    {
        Time.timeScale = 0;
        finalScore.SetActive(true);
    }

    public void UpdateBugCounter()
    {
        bugsKilled++;
        UpdateCounter(bugCounter, bugsKilled, levelData.LevelGoals.Bugs);
        //bugCounter.text = bugsKilled + " / " + levelData.LevelGoals.Bugs;
    }

    public void UpdateCoinsCounter()
    {
        coinsCollected++;
        UpdateCounter(coinsCounter, coinsCollected, levelData.LevelGoals.Coins);
        //coinsCounter.text = coinsCollected + " / " + levelData.LevelGoals.Coins;
    }

    void UpdateCounter(TextMeshProUGUI counterTxt, int currentCounter, int totalCounter)
    {
        counterTxt.text = currentCounter + " / " + totalCounter;
    }
}