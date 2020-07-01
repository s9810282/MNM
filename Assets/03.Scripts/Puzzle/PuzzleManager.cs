using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    [SerializeField] Puzzle puzzle;
    [SerializeField] Image[] puzzleComponent;
    [SerializeField] GameObject option;

    [Space(3f)]
    [Header("Viewer")]
    [SerializeField] Text scriptText; //대사 및 문제 설명 text
    [SerializeField] Text characterText; //말하는 이의 텍스트


    public Text ScriptText { get { return scriptText; } set { scriptText = value; } }
    public Text CharacterText { get { return characterText; } set { characterText = value; } }


    private Fade_InOut fade_InOut;

    private List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
    private int currentLine = 0;

    // Start is called before the first frame update
    void Start()
    {
        fade_InOut = new Fade_InOut();

        data = new List<Dictionary<string, string>>();
        currentLine = 0;

        //OnPuzzle();
    }

    public void OnPuzzle(string str = null)
    {
        StoryManager.Instance.IsPuzzle = true;

        foreach (var item in puzzleComponent)
        {
            item.gameObject.SetActive(true);
            fade_InOut.FadeIn(this, item);
        }

        puzzle.gameObject.SetActive(true);

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


    public void Replay()
    {

    }

    public void OnOption()
    {
        option.gameObject.SetActive(true);
    }



    public void ResetText()
    {
        scriptText.text = null;
        characterText.text = null;

        scriptText.alignment = TextAnchor.UpperLeft;
    }

    public void EndText()
    {
        scriptText.alignment = TextAnchor.UpperCenter;
        scriptText.text = puzzle.PuzzleQuestionExposition;

        puzzle.PuzzleQuestionText.text = puzzle.PuzzleQuestion;
    }

    public void ReadPuzzleText(string str = "1-3")
    {
        scriptText.alignment = TextAnchor.UpperLeft;

        scriptText.text = null;
        characterText.text = null;
        puzzle.PuzzleQuestionText.text = null;

        data = StoryManager.Instance.Data;
    }

    public void StartCoroutine_ReadText()
    {
        StartCoroutine(ReadText());
    }

    IEnumerator ReadText()
    {
        yield return new WaitUntil(() => Fade_InOut.IsFade);

        scriptText.alignment = TextAnchor.UpperLeft;

        WaitForSeconds waitTime = new WaitForSeconds(0.075f);

        scriptText.text = "";
        characterText.text = null;


        #region Text  Speaker

        string str = data[currentLine]["Text"];
        Debug.Log(str);

        if (str == null)
            yield break;

        characterText.text = data[currentLine]["Speaker"];

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

    IEnumerator SetAcitivityFalse(GameObject obj)
    {
        yield return new WaitUntil(() => Fade_InOut.IsFade);

        obj.SetActive(false);
    }
}
