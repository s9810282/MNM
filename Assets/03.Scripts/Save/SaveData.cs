using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string captureImagePath;

    public string csvFileName;
    public int csvFileLine;

    public int playTime = 0;
    

    public SaveData()
    {

    }

    public SaveData(string imagePath, string fileName, int fileLine, int _playTime)
    {
        captureImagePath = imagePath;
        csvFileName = fileName;
        csvFileLine = fileLine;
        playTime = _playTime;
    }
} 
