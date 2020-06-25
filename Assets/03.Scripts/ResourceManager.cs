using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine;
using Spine.Unity;

public class ResourceManager : MonoBehaviour
{
    [Header("SourceImagae")]
    [SerializeField] SourceImage[] spritesPos;


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

    public void ShowImage(string str)
    {
       
    }

    public void ShowBackGround(string str)
    {
        
    }

    public void ShowCharacter(string str)
    {
       
    }
}
