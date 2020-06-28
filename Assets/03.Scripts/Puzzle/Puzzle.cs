using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    [SerializeField] protected Answer answer;

    [SerializeField] protected Image[] puzzleComponent;

    [SerializeField] protected Fade_InOut fade_InOut;

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
        
        answer.offAnswerBtn.onClick.AddListener(OffAnswer);
        answer.endAnswerBtn.onClick.AddListener(CheckAnswer);
    }

    public virtual void PuzzleStart()
    {
        gameObject.SetActive(true);

        foreach (var item in puzzleComponent)
        {
            StoryManager.Instance.IsPuzzle = true;
            fade_InOut.FadeIn(this, item);
        }

    } //임시로 제작 추후 변경 예정

    public void OnAnswer()
    {
        answer.gameObject.SetActive(true);
    }

    public void OffAnswer()
    {
        answer.gameObject.SetActive(false);
    }

    public virtual void CheckAnswer()
    {

    }
}
