using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    [Header("Puzzle & Answer")]
    [SerializeField] protected Answer answer;
    [SerializeField] protected Image[] puzzleComponent;

    [Header("Puzzle Question")]
    [TextArea]
    [SerializeField] protected string puzzleQuestion;


    [Header("Puzzle Answer TextFile Name")]
    [SerializeField] protected string correctAnswerScripts;
    [SerializeField] protected string aWrongAnswerScripts;


    [Header("Next FileName")]
    [SerializeField] protected string fileName;

    [SerializeField] protected Fade_InOut fade_InOut;

    protected bool isPuzzleText;
    protected bool isCorrect;

    public string PuzzleQuestion { get { return puzzleQuestion; } }

    public string FileName { get { return fileName; } set { fileName = value; } }
    public bool IsPuzzleText { get { return isPuzzleText; } set { isPuzzleText = value; } }
    public bool IsCorrect { get { return isCorrect; } set { isCorrect = value; } }

    public void StartResetField()
    {
        fade_InOut = new Fade_InOut();
        isPuzzleText = false;
    }

    public virtual void PuzzleStart()
    {
        foreach (var item in puzzleComponent)
        {
            item.gameObject.SetActive(true);
            fade_InOut.FadeIn(this, item);
        }

    } 

    public virtual void PuzzleEnd()
    {
        foreach (var item in puzzleComponent)
        {
            fade_InOut.FadeOut(this, item);
            StartCoroutine(SetAcitivityFalse(item.gameObject));
        }
        //gameObject.SetActive(false);
    } //임시로 제작 추후 변경 예정


    public void OnAnswer()
    {
        answer.gameObject.SetActive(true);
    }

    //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    public virtual void CheckAnswer()
    {

    }
    
    public virtual IEnumerator ShowAnswerResultText(string str)
    {
        yield return null;
    }

    IEnumerator SetAcitivityFalse(GameObject obj)
    {
        yield return new WaitUntil(() => Fade_InOut.IsFadeEnd);

        obj.SetActive(false);
    }
}
