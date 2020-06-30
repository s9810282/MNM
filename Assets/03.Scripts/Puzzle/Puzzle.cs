using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    [Header("Puzzle & Answer")]
    [SerializeField] protected Answer answer;

    [SerializeField] protected Image[] puzzleComponent;

    [SerializeField] protected Text puzzleQuestionText;

    [Header("Puzzle Question")]
    [TextArea]
    [SerializeField] protected string puzzleQuestionExposition;
    [TextArea]
    [SerializeField] protected string puzzleQuestion;

    [Header("Puzzle Answer TextFile Name")]
    [SerializeField] protected string aWrongText;
    [SerializeField] protected string correctAnswer;

    [SerializeField] protected Fade_InOut fade_InOut;

    protected bool isPuzzleText;

    public string PuzzleQuestionExposition { get { return puzzleQuestionExposition; } }
    public string PuzzleQuestion { get { return puzzleQuestion; } }

    public Text PuzzleQuestionText { get { return puzzleQuestionText; } }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartResetField()
    {
        fade_InOut = new Fade_InOut();
        isPuzzleText = false;
    }

    public virtual void PuzzleStart()
    {
        gameObject.SetActive(true);

        StoryManager.Instance.IsPuzzle = true;

        foreach (var item in puzzleComponent)
        {
            item.gameObject.SetActive(true);
            fade_InOut.FadeIn(this, item);
        }

    } //임시로 제작 추후 변경 예정


    public virtual void ResetBtn()
    {

    }

    public virtual void HintBtn()
    {

    }   


    public virtual void CheckAnswer()
    {

    }
}
