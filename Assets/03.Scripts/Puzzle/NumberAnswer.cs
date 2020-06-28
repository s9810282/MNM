using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberAnswer : Answer
{
    void Start()
    {
        inputText.text = null;
    }

    public void DeleteOne()
    {
        string str = inputText.text;
        str.Remove(str.Length - 1, 1);

        inputText.text = str;
    }

    #region bumber button

    public void Button_0()
    {
        inputText.text += 0;
    }

    public void Button_1()
    {
        inputText.text += 1;
    }

    public void Button_2()
    {
        inputText.text += 2;
    }

    public void Button_3()
    {
        inputText.text += 3;
    }

    public void Button_4()
    {
        inputText.text += 4;
    }

    public void Button_5()
    {
        inputText.text += 5;
    }

    public void Button_6()
    {
        inputText.text += 6;
    }

    public void Button_7()
    {
        inputText.text += 7;
    }

    public void Button_8()
    {
        inputText.text += 8;
    }

    public void Button_9()
    {
        inputText.text += 9;
    }

    #endregion
}
