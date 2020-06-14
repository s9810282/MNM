using System.Collections;
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

    string path = "/data.dat";

    SaveData gamedata;
    public SaveData GameDatas { set { gamedata = value; } get { return gamedata; } }

    public void Awake()
    {
        gamedata = new SaveData();

        Debug.Log(Application.persistentDataPath + path);

    }

    //public void FileCheck(string fileName = null)
    //{
    //    if (System.IO.File.Exists(Application.persistentDataPath + fileName + path)) //이 파일 경로가 존재하는지 안하는지 확인  존재한다면 세이브 파일이이미 있는 것이므로 로드
    //    {
    //        Load();
    //    }
    //    else
    //    {
    //        Save();
    //        Load();
    //    }
    //}

    public void Save(SaveData _gamedata, string fileName = null) //경로에다가 저장
    {
        DataManager.BinarySerialize<SaveData>(_gamedata, Application.persistentDataPath + fileName + path);
    }

    public void Load(SaveData _gamedata, string fileName = null) //경로에서 불러다가 gamadata에 저장
    {
        _gamedata = DataManager.BinaryDeserialize<SaveData>(Application.persistentDataPath + fileName + path);
    }
}
