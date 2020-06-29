using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionAnswer : Answer
{
    

    // Start is called before the first frame update
    void Start()
    {
        selectNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseOne()
    {
        selectNum = 1;
    }

    public void ChooseTwo()
    {
        selectNum = 2;
    }

    public void ChooseThree()
    {
        selectNum = 3;
    }
}
