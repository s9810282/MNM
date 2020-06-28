using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicalFindColor : Puzzle
{
    [SerializeField] Text expositionText;

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
        fade_InOut.FadeIn(this, expositionText);
        
    }

    public override void CheckAnswer()
    {
        if(answer.inputText.text == 3.ToString())
        {

        }
        else
        {

        }
    }
}
