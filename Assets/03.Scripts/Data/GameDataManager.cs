﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Puzzle;

public class GameDataManager
{
    private static GameDataManager instance;
    public static GameDataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameDataManager();
                instance.Awake();
            }

            return instance;
        }
    }

    SaveData gamedata;
    public SaveData GameDatas { set { gamedata = value; } get { return gamedata; } }

    public void Awake()
    {
        gamedata = new SaveData();

        Debug.Log(Application.persistentDataPath);

    }

    public void Save(SaveData _gamedata, string fileName = null) //경로에다가 저장
    {
        DataManager.BinarySerialize<SaveData>(_gamedata, Application.persistentDataPath + fileName);
    }

    public void Load(SaveData _gamedata, string fileName = null) //경로에서 불러다가 gamadata에 저장
    {
        _gamedata = DataManager.BinaryDeserialize<SaveData>(Application.persistentDataPath + fileName);
    }
}
