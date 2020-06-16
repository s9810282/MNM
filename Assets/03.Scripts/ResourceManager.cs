using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine;
using Spine.Unity;

public class ResourceManager : MonoBehaviour
{
    [Header("Image")]
    [SerializeField] Image[] spritesPos;

    [SerializeField] Sprite[] sprites;

    [Header("BackGround")]

    [SerializeField] Image backGround;

    [SerializeField] Sprite[] backGroundSprites;

    [Header("Character")]

    [SerializeField] SkeletonGraphic[] spineCharacters;

    [SerializeField] SkeletonDataAsset[] skeletonDataAsset;

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
        Debug.Log("Show Image");
        StoryManager.Instance.IsNotText = true;

        //I.M11  
        //M.L.R.B
        char tmpPos = str[2]; //M
        int position = 0; //M

        string tmpSprite = str[3].ToString();
        int sprite = int.Parse(tmpSprite); //1

        char type = str[4]; //1


        if (tmpPos == 'M')
            position = 0;
        else if (tmpPos == 'L')
            position = 1;
        else if (tmpPos == 'R')
            position = 2;

        switch (type)
        {
            case '1': //그냥 띄움
                StartCoroutine(Image_Type1(position, sprite));
                break;

            case '2': //서서히 띄움
                StartCoroutine(Image_Type2(position, sprite));
                break;

            case '3': //서서히 사라짐
                StartCoroutine(Image_Type3(position, sprite));
                break;
        }
    }

    public void ShowBackGround(string str)
    {
        //B.11
        //  StoryManager.Instance.IsNotText = true;

        char type = str[3];

        string tmpSprite = str[2].ToString();
        int sprite = int.Parse(tmpSprite); //1

        switch (type)
        {
            case '1': //그냥 배경이 바뀜
                backGround.sprite = backGroundSprites[sprite];
                break;

            case '2': //서서히 배경이 바뀜
                StartCoroutine(BackGround_Type2(sprite));
                break;
            
        }
    }

    public void ShowCharacter(string str)
    {
        //나머지 캐릭터를 받아봐야 어떻게 해야할지 될듯
        //지금은 case문 구분에 따른 함수 실행만
        //C.L11
        Debug.Log("Show Character");
        StoryManager.Instance.IsNotText = true;

        char tmpPos = str[2]; //C
        int position = 0; //M

        string tmpSprite = str[3].ToString();
        int sprite = int.Parse(tmpSprite); //1

        char type = str[4]; //1


        if (tmpPos == 'M')
            position = 0;
        else if (tmpPos == 'L')
            position = 1;
        else if (tmpPos == 'R')
            position = 2;

        switch (type)
        {
            case '1': //그냥 띄움
                
                break;

            case '2': //서서히 띄움
                StartCoroutine(Character_Type2(position, sprite));
                break;

            case '3': //서서히 사라짐
                
                break;
        }
    }



    public IEnumerator Image_Type1(int showpos, int showSprite)
    {
        Debug.Log("Type 1");

        Vector2 size = new Vector2(sprites[showSprite].rect.width, sprites[showSprite].rect.height);

        spritesPos[showpos].GetComponent<RectTransform>().sizeDelta = size;
        spritesPos[showpos].sprite = sprites[showSprite];

        yield return new WaitForSeconds(0.1f);

        StoryManager.Instance.IsNotText = false;
        StoryManager.Instance.IsLineEnd = true;
        
    } //이미지를 띄움, 

    public IEnumerator Image_Type2(int showpos, int showSprite)
    {
        Debug.Log("Type 2");

        Vector2 size = new Vector2(sprites[showSprite].rect.width, sprites[showSprite].rect.height);

        spritesPos[showpos].GetComponent<RectTransform>().sizeDelta = size;
        spritesPos[showpos].sprite = sprites[showSprite];

        fade_InOut.FadeIn(this, spritesPos[showpos]);

        yield return new WaitForSeconds(0.1f);

        StoryManager.Instance.IsNotText = false;
        StoryManager.Instance.IsLineEnd = true;

    } //이미지를 서서히 띄움, 

    public IEnumerator Image_Type3(int showpos, int showSprite)
    {
        Debug.Log("Type 3");

        //spritesPos[showpos].sprite = sprites[showSprite];

        fade_InOut.FadeOut(this, spritesPos[showpos]);

        yield return new WaitUntil(() => StoryManager.Instance.IsFadeEnd);

        Vector2 size = new Vector2(sprites[showSprite].rect.width, sprites[showSprite].rect.height);
        spritesPos[showpos].GetComponent<RectTransform>().sizeDelta = size;

        spritesPos[showpos].sprite = sprites[showSprite]; //fade로 사라지고 투명색으로 교체
        spritesPos[showpos].color = new Color(255, 255, 255, 255);
      
        yield return new WaitForSeconds(0.1f);

        StoryManager.Instance.IsNotText = false;
        StoryManager.Instance.IsLineEnd = true;


    } //이미지를 서서히 지움

    public IEnumerator BackGround_Type2(int showSprite)
    {
        fade_InOut.FadeOut(this,backGround);

        yield return new WaitUntil(() => StoryManager.Instance.IsFadeEnd);

        backGround.sprite = backGroundSprites[showSprite];
        fade_InOut.FadeIn(this, backGround);

        yield return new WaitUntil(() => StoryManager.Instance.IsFadeEnd);

    }

    public IEnumerator Character_Type2(int showPos, int showCharacter)
    {
        spineCharacters[showPos].skeletonDataAsset = skeletonDataAsset[showCharacter];
        spineCharacters[showPos].gameObject.SetActive(true);

        fade_InOut.FadeIn(this, spineCharacters[showPos], 0.75f);

        yield return new WaitForSeconds(0.1f);

        StoryManager.Instance.IsNotText = false;
        StoryManager.Instance.IsLineEnd = true;
    } //캐릭터를 서서히 띄움
}
