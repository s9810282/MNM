using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager
{
    private static StoryManager instance;
    public static StoryManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new StoryManager();
                instance.Awake();
            }

            return instance;
        }
    }

    #region Field

    private List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
    

    private int currentLine = 0;
    private string fileName;
    private int fileNum;

    private int playTime;

    private float textSpeed;

    private bool isNewGame = true;
    private bool isNeverSkip = false;
    private bool isLineEnd = false;
    private bool isNotText = false;

    private bool isTouchUI = false;
    private bool isPuzzle = false;

    #endregion

    #region Property

    public List<Dictionary<string, string>> Data { get { return data; } set { data = value; } }

    public int CurrentLine { get { return currentLine; } set { currentLine = value; } }
    public string FileName { get { return fileName; } set { fileName = value; } }
    public int FileNum { get { return fileNum; } set { fileNum = value; } }

    public int PlayTime { get { return playTime; } set { playTime = value; } }

    public float TextSpeed { get { return textSpeed; } set { textSpeed = value; } }

    public bool IsNewGame { get { return isNewGame; } set { isNewGame = value; } }
    public bool IsNeverSkip { get { return isNeverSkip; } set { isNeverSkip = value; } }
    public bool IsLineEnd { get { return isLineEnd; } set { isLineEnd = value; } }

    public bool IsTouchUI { get { return isTouchUI; } set { isTouchUI = value; } }
    public bool IsPuzzle { get { return isPuzzle; } set { isPuzzle = value; } }

    #endregion

    public void Awake()
    {
        data = new List<Dictionary<string, string>>();

        fileName = string.Empty;
        fileNum = 0;

        playTime = 0;

        currentLine = 0;

        isLineEnd = false;
        isNeverSkip = false;
        isNewGame = true;

        isTouchUI = false;
        isPuzzle = false;
    }

    public List<Dictionary<string, string>> LoadCSV(string _fileName)
    {
        data = CSVReader.Read(_fileName);

        fileName = _fileName;
        fileNum++;
        currentLine = 0;

        return data;
    }

    public List<Dictionary<string, string>> LoadCSV()
    {
        data = CSVReader.Read(fileName);       
        return data;
    }

    public string ReturnLine(string typeName)
    {
        return data[currentLine][typeName];
    }

    public string ReturnLoadLine(string fileNAme, string typeName, int _currentLine)
    {
        List<Dictionary<string, string>> tmp = CSVReader.Read(fileNAme);
        return tmp[_currentLine][typeName];
    }
}
