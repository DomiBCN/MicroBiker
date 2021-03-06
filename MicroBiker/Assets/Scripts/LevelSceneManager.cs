﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSceneManager : MonoBehaviour {

    public LevelSceneManager instance;
    
    public GameObject levelPrefab;
    public Transform levelBtnParent;
    
    List<Level> gameLevels;//contains all levels data
    LevelBtn btnLevel;//Used to pass data to each level btn instantiated

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        gameLevels = GamePersister.LoadLevelsData();
        AddLevels();
    }
    
    void AddLevels()
    {
        if(gameLevels != null)
        {
            foreach (var level in gameLevels)
            {
                GameObject levelBtn = new GameObject();
                levelBtn = Instantiate(levelPrefab, levelBtnParent);
                btnLevel = levelBtn.GetComponent<LevelBtn>();
                btnLevel.levelData = level;
                btnLevel.InitBtnData();
            }
        }
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("StartScene");
    }
}
