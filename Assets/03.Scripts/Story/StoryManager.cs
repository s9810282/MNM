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
    //private bool isShowText = false;
    private string fileName;
    private int fileNum;

    private bool isNewGame = true;
    private bool isNeverSkip = false;
    private bool isLineEnd = false;
    private bool isNotText = false;

    private bool isTouchUI = false;
    private bool isFadeEnd = true;

    #endregion

    #region Property

    public List<Dictionary<string, string>> Data { get { return data; } set { data = value; } }

    public int CurrentLine { get { return currentLine; } set { currentLine = value; } }
    public string FileName { get { return fileName; } set { fileName = value; } }
    public int FileNum { get { return fileNum; } set { fileNum = value; } }

    public bool IsNewGame { get { return isNewGame; } set { isNewGame = value; } }
    public bool IsNeverSkip { get { return isNeverSkip; } set { isNeverSkip = value; } }
    public bool IsLineEnd { get { return isLineEnd; } set { isLineEnd = value; } }
    public bool IsNotText { get { return isNotText; } set { isNotText = value; } }

    public bool IsTouchUI { get { return isTouchUI; } set { isTouchUI = value; } }
    public bool IsFadeEnd { get { return isFadeEnd; } set { isFadeEnd = value; } }

    #endregion

    public void Awake()
    {
        data = new List<Dictionary<string, string>>();

        currentLine = 0;

        isLineEnd = false;
        isNeverSkip = false;
        isNotText = false;
        isNewGame = true;

        isTouchUI = false;
        isFadeEnd = true;

        fileName = string.Empty;
        fileNum = 0;
    }

    public List<Dictionary<string, string>> LoadCSV(string _fileName)
    {
        data = CSVReader.Read(_fileName);

        fileName = _fileName;
        fileNum++;
        currentLine = 0;

        return data;
    }

    public string ReturnLine(string typeName)
    {
        return data[currentLine][typeName];
    }
}
