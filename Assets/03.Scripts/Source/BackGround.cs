using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGround : StatementOBJ
{
    [SerializeField] Image backGround;

    [SerializeField] string[] backGroundSpriteName;

    [SerializeField] Sprite[] backGroundSprites;

    private Dictionary<string, Sprite> dic_backGround;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < backGroundSpriteName.Length; i++)
            dic_backGround.Add(backGroundSpriteName[i], backGroundSprites[i]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Change(string sourceName)
    {
        backGround.sprite = dic_backGround[sourceName];
    }

    public override void Delete(string sorceName = null)
    {
        backGround.sprite = null;
    }

    public override void SlowlyChange(string sourceName)
    {
        StartCoroutine(SlowChange(sourceName));
    }

    public override void SlowlyFadeOut(string sorceName = null)
    {
        StartCoroutine(SlowFadeOut());
    }

    public override void SlowlyFadeIn(string sourceName)
    {
        StartCoroutine(SlowFadeIn(sourceName));
    }

    public override IEnumerator SlowChange(string sourceName)
    {
        fade_InOut.FadeOut(this,backGround);

        yield return new WaitUntil(() => Fade_InOut.IsFade);

        backGround.sprite = dic_backGround[sourceName];
        fade_InOut.FadeIn(this, backGround);

        yield return new WaitUntil(() => Fade_InOut.IsFade);
    }

    public override IEnumerator SlowFadeIn(string sourceName)
    {
        backGround.sprite = dic_backGround[sourceName];
        fade_InOut.FadeIn(this, backGround);

        yield return new WaitUntil(() => Fade_InOut.IsFade);
    }

    public override IEnumerator SlowFadeOut()
    {
        fade_InOut.FadeOut(this, backGround);

        yield return new WaitUntil(() => Fade_InOut.IsFade);
    }

}
