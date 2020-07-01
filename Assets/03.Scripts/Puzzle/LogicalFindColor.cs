using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicalFindColor : Puzzle
{
    // Start is called before the first frame update
    void Start()
    {
        StartResetField();
        PuzzleStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void PuzzleStart()
    {
        base.PuzzleStart();      
    }





    public override void CheckAnswer()
    {
        string str;

        if (answer.SelectNum == 2)
        {
            isCorrect = true;
            str = correctAnswerScripts;
        }
        else
        {
            isCorrect = false;
            str = aWrongAnswerScripts;
        }

        answer.gameObject.SetActive(false);
        //StartCoroutine(ShowAnswerResultText(str));

        PuzzleManager.Instance.ChkAnswer(str);
    }

    public override IEnumerator ShowAnswerResultText(string str)
    {
        isPuzzleText = true;

        WaitForSeconds waitTime = new WaitForSeconds(0.075f);

        PuzzleManager.Instance.CharacterText.text = "Girl";
        PuzzleManager.Instance.ScriptText.text = null;


        for (int i = 0; i < str.Length; i++)
        {
            PuzzleManager.Instance.ScriptText.text += str[i];
            yield return waitTime;
        }

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        isPuzzleText = false;

        if (isCorrect)
        {
            StoryManager.Instance.LoadCSV(fileName);
            StoryManager.Instance.CurrentLine--;

            PuzzleManager.Instance.ResetText();
            PuzzleManager.Instance.OffPuzzle();
            PuzzleEnd();
        }
        else
        {
            PuzzleManager.Instance.ResetText();
            PuzzleManager.Instance.EndText();
        }       

        yield return null;
    }
}
