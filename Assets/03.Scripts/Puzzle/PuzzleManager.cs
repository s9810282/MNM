using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;


public class PuzzleManager : MonoBehaviour
{
    private static PuzzleManager instance;
    public static PuzzleManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(PuzzleManager)) as PuzzleManager;
            }

            return instance;
        }
    }

    [Header("Puzzle")]
    [SerializeField] Puzzle puzzle; //사실상 배열, 퍼즐 들을 담고있음
    [SerializeField] Image[] puzzleComponent; //배경과 함께 퍼즐버튼 
    [SerializeField] Text puzzleQuestionText; //게임 설명이 나올데
    [SerializeField] GameObject option;

    [Header("Puzzle Buttons")]
    [SerializeField] Button replayBtn; //퍼즐의 함수를 스크맆트에서 담아줌
    [SerializeField] Button resetBtn;
    [SerializeField] Button answerBtn;
    [SerializeField] Button hintBtn;
    [SerializeField] Button puzzleOptionBtn;

    [Space(3f)]
    [Header("Option Slider")]
    [SerializeField] Slider textSpeedSlider;
    [SerializeField] Slider mainSoundSlider;
    [SerializeField] Slider soundEffectSlider;
    [SerializeField] Slider bgmSoundSlider;

    [Space(3f)]
    [Header("Viewer")]
    [SerializeField] GameObject puzzleTextOBJ;
    [SerializeField] Image puzzleViewerBackGround; //검정 배경
    [SerializeField] GameObject speaker; //말하는 캐릭터
    [SerializeField] Text scriptText; //대사 및 문제 설명 text
    [SerializeField] Text characterText; //말하는 이의 텍스트


    public Text ScriptText { get { return scriptText; } set { scriptText = value; } }
    public Text CharacterText { get { return characterText; } set { characterText = value; } }

    private Fade_InOut fade_InOut;

    private Puzzle currentPuzzle;

    private List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
    private int currentLine = 0;

    // Start is called before the first frame update
    void Start()
    {
        fade_InOut = new Fade_InOut();

        data = new List<Dictionary<string, string>>();
        currentLine = 0;

        SetPuzzleButtons();
    }

    public void OnPuzzle(string str = null)
    {
        StoryManager.Instance.IsPuzzle = true;
        currentPuzzle = puzzle; //dic_puzzle[str];

        foreach (var item in puzzleComponent)
        {
            item.gameObject.SetActive(true);
            fade_InOut.FadeIn(this, item, 1.5f);
        }

        puzzle.gameObject.SetActive(true);
        puzzleTextOBJ.gameObject.SetActive(true);
        

        puzzleViewerBackGround.gameObject.SetActive(true);
        scriptText.gameObject.SetActive(true);
        speaker.gameObject.SetActive(true);

        fade_InOut.FadeIn(this, puzzleViewerBackGround, 0.7f);
        fade_InOut.FadeIn(this, scriptText);
        fade_InOut.FadeIn(this, speaker.GetComponent<SkeletonGraphic>());

        ReadPuzzleText(str);
        StartCoroutine_ReadText();

    } //나중에 str값에 따라 PuzzleText를 읽고 첫줄에 있는 퍼즐을 나타나게함

    public void OffPuzzle(string str = null)
    {      
        foreach (var item in puzzleComponent)
        {
            fade_InOut.FadeOut(this, item);
            StartCoroutine(SetAcitivityFalse(item.gameObject));
        }

        //puzzle.gameObject.SetActive(false);

        StoryManager.Instance.IsPuzzle = false;
    }


    public void SetPuzzleButtons() //퍼즐 버튼들 미리 설정해줌
    {
        answerBtn.onClick.AddListener(puzzle.OnAnswer);

    }

    public void Answer()
    {

    }

    public void Resets()
    {
        
    }

    public void Replay()
    {

    }

    public void OnOption()
    {
        SettingOptionSlider();
        option.gameObject.SetActive(true);
    }

    public void OffOption()
    {
        option.gameObject.SetActive(false);
    }

    public void SettingOptionSlider()
    {
        mainSoundSlider.value = SoundManager.Instance.SoundValue.MainSoundValue;
        soundEffectSlider.value = SoundManager.Instance.SoundValue.SoundEffectValue;
        bgmSoundSlider.value = SoundManager.Instance.SoundValue.BgmValue;

        textSpeedSlider.value = StoryManager.Instance.TextSpeed;
    }


    public void ChkAnswer(string str)
    {
        puzzleTextOBJ.gameObject.SetActive(true);

        puzzleViewerBackGround.gameObject.SetActive(true);
        scriptText.gameObject.SetActive(true);
        speaker.gameObject.SetActive(true);

        fade_InOut.FadeIn(this, puzzleViewerBackGround, 0.7f);
        fade_InOut.FadeIn(this, scriptText);
        fade_InOut.FadeIn(this, speaker.GetComponent<SkeletonGraphic>());

        StartCoroutine(ShowAnswerResultText(str));
    }

    public IEnumerator ShowAnswerResultText(string str)
    {
        yield return new WaitUntil(() => Fade_InOut.IsFadeEnd);
        WaitForSeconds waitTime = new WaitForSeconds(0.075f);

        scriptText.text = null;


        for (int i = 0; i < str.Length; i++)
        {
            scriptText.text += str[i];
            yield return waitTime;
        }

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));


        if (puzzle.IsCorrect)
        {
            StoryManager.Instance.LoadCSV(puzzle.FileName);
            StoryManager.Instance.CurrentLine--;

            ResetText();
            StartCoroutine(EndTextFalse());          
            OffPuzzle();
            puzzle.PuzzleEnd();
        }
        else
        {
            ResetText();
            EndText();
        }

        yield return null;
    }



    public void ResetText()
    {
        scriptText.text = null;
        //characterText.text = null;

        scriptText.alignment = TextAnchor.UpperLeft;
    }

    public void EndText()
    {
        scriptText.alignment = TextAnchor.UpperCenter;
        puzzleQuestionText.text = puzzle.PuzzleQuestion;

        StartCoroutine(EndTextFalse());

    } //대사 끝날시 문제로 교체


    public void ReadPuzzleText(string str = "1-3")
    {
        scriptText.alignment = TextAnchor.UpperLeft;

        scriptText.text = null;
        //characterText.text = null;

        data = StoryManager.Instance.Data;
    }

    public void StartCoroutine_ReadText()
    {
        StartCoroutine(ReadText());
    }

    IEnumerator ReadText()
    {
        yield return new WaitUntil(() => Fade_InOut.IsFadeEnd);

        scriptText.alignment = TextAnchor.UpperLeft;

        WaitForSeconds waitTime = new WaitForSeconds(0.075f);

        scriptText.text = "";
        //characterText.text = null;


        #region Text  Speaker

        string str = data[currentLine]["Text"];
        Debug.Log(str);

        if (str == null)
            yield break;

        //characterText.text = data[currentLine]["Speaker"];

        for (int i = 0; i < str.Length; i++)
        {
            scriptText.text += str[i];
            yield return waitTime;
        }

        #endregion

        currentLine++;
        if (currentLine >= data.Count)
        {
            Debug.Log("Puzzle Text End");
            EndText();
            yield break;
        }

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        StartCoroutine(ReadText());

        yield break;
    } //텍스트 한줄 출력

    IEnumerator EndTextFalse()
    {
        fade_InOut.FadeOut(this, puzzleViewerBackGround);
        fade_InOut.FadeOut(this, scriptText);
        fade_InOut.FadeOut(this, speaker.GetComponent<SkeletonGraphic>());

        yield return new WaitUntil(() => Fade_InOut.IsFadeEnd);

        puzzleViewerBackGround.gameObject.SetActive(false);
        scriptText.gameObject.SetActive(false);
        speaker.gameObject.SetActive(false);

        puzzleTextOBJ.gameObject.SetActive(false);
    }

    IEnumerator SetAcitivityFalse(GameObject obj)
    {
        yield return new WaitUntil(() => Fade_InOut.IsFadeEnd);

        obj.SetActive(false);
    }
}
