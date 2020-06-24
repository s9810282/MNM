using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Screenshot
{
    private static Screenshot instance;
    public static Screenshot Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Screenshot();       
            }

            return instance;
        }
    }

    private RawImage photoImage;
    public RawImage PhotoImage { get { return photoImage; } set { photoImage = value; } }

    private Texture2D texture;
    public Texture2D Texture { get { return texture; } set { texture = value; } }


    //마지막으로 찍은 사진의 경로
    private string dataPath;
    public string DataPath { get { return dataPath; } set { dataPath = value; } }

    private string captureDate;
    public string CaptureDate { get { return captureDate; } set { captureDate = value; } }

    public Texture2D Return_Capture(MonoBehaviour player,string _path)
    {
        dataPath = _path;
        player.StartCoroutine(GetPhotoDelay(_path));
   
        return texture;
    }

    public void Photo(string _path)
    {
        ScreenCapture.CaptureScreenshot(Application.persistentDataPath + _path);
    }

    public Texture2D GetPhoto(string _path)
    {
        //Debug.Log(_path);
        string url = Application.persistentDataPath  + _path;
        var bytes = File.ReadAllBytes(url);
        texture = new Texture2D(73, 73);
        texture.LoadImage(bytes);

        return texture;
    }

    IEnumerator GetPhotoDelay(string _path)
    {
        Photo(_path);

        yield return new WaitForSeconds(0.5f);

        texture = GetPhoto(_path);
    }
}
