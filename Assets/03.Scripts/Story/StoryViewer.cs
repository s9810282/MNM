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

    [SerializeField] Image fade_BackGround;


    [SerializeField] string[] CSV_FileNames;

    Fade_InOut fade_InOut;

    private IEnumerator textCoroutine;
    private bool isTextSkip = false;

    // Start is called before the first frame update    
    void Start()
    {
        fade_InOut = new Fade_InOut();
        fade_InOut.SceneStart(this, fade_BackGround);

        storyManager = StoryManager.Instance;
        textCoroutine = ReadLine();

        if (storyManager.IsNewGame)
            storyManager.LoadCSV(CSV_FileNames[storyManager.FileNum]);

        StartCoroutine(FadeToStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (!storyManager.IsFadeEnd)
            return;

        if (storyManager.IsTouchUI)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Input");

            if (storyManager.IsNeverSkip)
                return;

            if (storyManager.IsNotText)
                return;

            //더 나올 텍스트가 없다면
            if (storyManager.IsLineEnd)
            {
                NextLine();
                return;
            }

            //천천히 나오던 텍스트를 한번에 출력
            TextSkip();
        }

        if (isTextSkip) //마우스 클릭이 2,3프레임에 들어가기에 한번 넘어가기 위한 작업
            storyManager.IsLineEnd = true;
    }

    public void TextSkip()
    {
        StopCoroutine(textCoroutine);
        scripteText.text = storyManager.Data[storyManager.CurrentLine]["Text"];

        isTextSkip = true;
        Debug.Log(storyManager.IsLineEnd);
    }

    public void NextLine()
    {
        //다음 줄을 가지고 진행
        Debug.Log(storyManager.IsLineEnd);
        storyManager.CurrentLine++;

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

        isTextSkip = false;

        storyManager.IsLineEnd = false;



        #region StateMent

        string stateMent = storyManager.Data[storyManager.CurrentLine]["Statement"];
        char typed = stateMent[0];
        Debug.Log(typed);
        if (typed.Equals('I')) //그냥 이미지
        {
            resoureceManager.ShowImage(stateMent);
        }
        else if(typed.Equals('B'))
        {
            resoureceManager.ShowBackGround(stateMent);
        }
        else if(typed.Equals('P')) //퍼즐.
        {

        }
        else if(typed.Equals('C')) //캐릭터
        {
            resoureceManager.ShowCharacter(stateMent);
        }

        #endregion

        #region Text  Character
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
        yield return new WaitUntil(() => storyManager.IsFadeEnd);

        isTextSkip = false;

        //새 게임이 아닌 로드 게임일 경우 여기가 아닌 LoadSlot 을 누를 때 처리
        
        Debug.Log(storyManager.Data.Count);
        StartCoroutine(textCoroutine);
    }
}