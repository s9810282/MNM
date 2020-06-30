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
        if (answer.SelectNum == 2)
        {
            Debug.Log("Sucess");
            PuzzleManager.Instance.ReadPuzzleText(correctAnswer);
        }
        else
        {
            Debug.Log("Fail");
            PuzzleManager.Instance.ReadPuzzleText(aWrongText);
        }

        answer.gameObject.SetActive(false);
        PuzzleManager.Instance.StartCoroutine_ReadText();
    }
}
