using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine;
using Spine.Unity;

public class ResourceManager : MonoBehaviour
{
    [Header("SourceImagae")]
    [SerializeField] SourceImage[] sourceImage;


    [Header("BackGround")]

    [SerializeField] BackGround backGround;


    [Header("Character")]

    [SerializeField] Character[] spineCharacters;

    Fade_InOut fade_InOut;

    // Start is called before the first frame update
    void Awake()
    {
        fade_InOut = new Fade_InOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowImage(string str) //str = SourceImage
    {
        int sourcePos = int.Parse(StoryManager.Instance.ReturnLine("S_position"));
        int sourceType = int.Parse(StoryManager.Instance.ReturnLine("S_drection"));

        sourceImage[sourcePos].stateChangeFunc[sourceType - 1].Invoke(str);
    }

    public void ShowBackGround(string str)
    {
        int backGroundType = int.Parse(StoryManager.Instance.ReturnLine("B_drection"));

        backGround.stateChangeFunc[backGroundType - 1].Invoke(str);
    }

    public void ShowCharacter(string str)
    {
        int characterPos = int.Parse(StoryManager.Instance.ReturnLine("C_position"));
        int characterType = int.Parse(StoryManager.Instance.ReturnLine("C_drection"));

        spineCharacters[characterPos].stateChangeFunc[characterType - 1].Invoke(str);
    }
}
