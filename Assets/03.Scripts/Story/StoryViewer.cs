using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryViewer : MonoBehaviour
{
    [SerializeField] ResourceManager resoureceManager;

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
        textCoroutine = ReadLine();

        if (storyManager.IsNewGame)
            storyManager.LoadCSV(CSV_FileNames[storyManager.FileNum]);
        else
            storyManager.LoadCSV();

        StartCoroutine(FadeToStart());
    }

    // Update is called once per frame
    void Update()
    {
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
            if (CSV_FileNames[storyManager.FileNum] == null)
                return;

            Debug.Log("Next File");
            storyManager.LoadCSV(CSV_FileNames[storyManager.FileNum]);
        }

        textCoroutine = ReadLine();
        StartCoroutine(textCoroutine);
    }



    //만약 소스가 비어있다면 한줄 출력                        소스 : 캐릭터 : 대사
    IEnumerator ReadLine()
    {
        WaitForSeconds waitTime = new WaitForSeconds(0.075f);


        scripteText.text = null;
        characterText.text = null;

        storyManager.IsLineEnd = false;

        #region StateMent

        string stateMent = storyManager.Data[storyManager.CurrentLine]["Statement"];
        char typed = stateMent[0];
        //Debug.Log(typed);
        if (typed.Equals('I')) //그냥 이미지
        {
            resoureceManager.ShowImage(stateMent);
        }
        else if (typed.Equals('B'))
        {
            resoureceManager.ShowBackGround(stateMent);
        }
        else if (typed.Equals('P')) //퍼즐.
        {

        }
        else if (typed.Equals('C')) //캐릭터
        {
            resoureceManager.ShowCharacter(stateMent);
        }

        #endregion

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
    }

    IEnumerator FadeToStart()
    {
        storyManager.IsLineEnd = false;

        yield return new WaitUntil(() => Fade_InOut.IsFade);
        StartCoroutine(textCoroutine);
    }

    IEnumerator TouchDown(float time)
    {
        yield return new WaitForSeconds(time);
        isTouchDown = false;
    }
}