using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryViewer : MonoBehaviour
{
    [SerializeField] ResourceManager resoureceManager;

    [SerializeField] PuzzleManager puzzleManager;

    [SerializeField] StoryManager storyManager;

    [SerializeField] Text scripteText;

    [SerializeField] Text characterText;


    [SerializeField] string[] CSV_FileNames;

    [SerializeField] float touchDownDelayTime;



    private IEnumerator textCoroutine;
    private bool isTextSkip = false;

    private bool isTouchDown = false;

    // Start is called before the first frame update    
    void Start()
    {
        storyManager = StoryManager.Instance;
        textCoroutine = ReadText();

        if (storyManager.IsNewGame)
            storyManager.LoadCSV(CSV_FileNames[storyManager.FileNum]);
        else
            storyManager.LoadCSV();

        StartCoroutine(FadeToStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (storyManager.IsPuzzle)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (isTouchDown)
                return;

            if (storyManager.IsTouchUI)
                return;

            if (!Fade_InOut.IsFade)
                return;

            isTouchDown = true;
            StartCoroutine(TouchDown(touchDownDelayTime));

            //더 나올 텍스트가 없다면
            if (storyManager.IsLineEnd)
            {
                NextLine();
                return;
            }

            //천천히 나오던 텍스트를 한번에 출력
            TextSkip();
        }
    }

    public void TextSkip()
    {
        StopCoroutine(textCoroutine);

        characterText.text = storyManager.Data[storyManager.CurrentLine]["Speaker"];
        scripteText.text = storyManager.Data[storyManager.CurrentLine]["Text"];

        storyManager.IsLineEnd = true;
    }

    public void NextLine()
    {
        storyManager.CurrentLine++;

        //만약 다음줄이 없다면 파일을 새로 읽음
        if (storyManager.Data.Count <= storyManager.CurrentLine)
        {
            Debug.Log(storyManager.Data.Count);
            Debug.Log(storyManager.CurrentLine);

            if (CSV_FileNames[storyManager.FileNum] == null)
                return;

            Debug.Log("Next File");
            storyManager.LoadCSV(CSV_FileNames[storyManager.FileNum]);
        }

        scripteText.text = null;
        characterText.text = null;

        ShowBackGround();
        ShowCharacter();
        ShowSourceImage();

        textCoroutine = ReadText();
        StartCoroutine(textCoroutine);
    }

    public void PuzzleStart()
    {
        puzzleManager.OnPuzzle();
    }
    //3
    public void ShowSourceImage()
    {
        string str = storyManager.ReturnLine("Source Image");

        if (str.Length > 0)
        {
            Debug.Log(str.Length);
            Debug.Log("SourceImage : " + str);
            resoureceManager.ShowImage(str);
        }
    }
    //1
    public void ShowBackGround()
    {
        string str = storyManager.ReturnLine("Background");

        if (str.Length > 0)
        {
            Debug.Log(str.Length);
            Debug.Log("BackGround Image : " + str);
            resoureceManager.ShowBackGround(str);
        }
    }
    //2
    public void ShowCharacter()
    {
        string str = storyManager.ReturnLine("Character Image");
        

        if (str.Length > 0)
        {
            Debug.Log(str.Length);
            Debug.Log("Character Imgage : " + str);
            resoureceManager.ShowCharacter(str);
        }
    }
    //last
    IEnumerator ReadText()
    {
        WaitForSeconds waitTime = new WaitForSeconds(0.075f);

        scripteText.text = null;
        characterText.text = null;

        storyManager.IsLineEnd = false;

        #region Text  Speaker
        string str = storyManager.Data[storyManager.CurrentLine]["Text"];

        if (str == null)
            yield break;

        characterText.text = storyManager.Data[storyManager.CurrentLine]["Speaker"];

        for (int i = 0; i < str.Length; i++)
        {
            scripteText.text += str[i];
            yield return waitTime;
        }

        #endregion

        yield return new WaitForSeconds(0.25f);
        storyManager.IsLineEnd = true;

        yield break;
    } //텍스트 출력

    IEnumerator FadeToStart()
    {
        storyManager.IsLineEnd = false;

        yield return new WaitUntil(() => Fade_InOut.IsFade);

        scripteText.text = null;
        characterText.text = null;

        ShowBackGround();
        ShowCharacter();
        ShowSourceImage();

        StartCoroutine(textCoroutine);
    }

    IEnumerator TouchDown(float time)
    {
        yield return new WaitForSeconds(time);
        isTouchDown = false;
    }
}