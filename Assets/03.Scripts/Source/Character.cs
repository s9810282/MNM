using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;


public class Character : StatementOBJ
{
    [SerializeField] SkeletonAnimation skeletonAnimation;

    [SerializeField] SkeletonGraphic spineCharacter;


    [SerializeField] string[] characterSpriteName;

    [SerializeField] SkeletonDataAsset[] characterSprites;

    private Dictionary<string, SkeletonDataAsset> dic_characterSprites;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < characterSpriteName.Length; i++)
            dic_characterSprites.Add(characterSpriteName[i], characterSprites[i]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Change(string sourceName)
    {
        spineCharacter.gameObject.SetActive(true);
        spineCharacter.skeletonDataAsset = dic_characterSprites[sourceName];
    }

    public override void Delete()
    {
        spineCharacter.gameObject.SetActive(false);
    }

    public override void SlowlyChange(string sourceName)
    {
        StartCoroutine(SlowChange(sourceName));
    }

    public override void SlowlyFadeOut()
    {
        StartCoroutine(SlowFadeOut());
    }

    public override void SlowlyFadeIn(string sourceName)
    {
        spineCharacter.gameObject.SetActive(true);
        StartCoroutine(SlowFadeIn(sourceName));
    }

    public override IEnumerator SlowChange(string sourceName)
    {
        fade_InOut.FadeOut(this, spineCharacter, 0.7f);

        yield return new WaitUntil(() => Fade_InOut.IsFade);

        spineCharacter.skeletonDataAsset = dic_characterSprites[sourceName];
        fade_InOut.FadeIn(this, spineCharacter, 0.7f);

        yield return new WaitUntil(() => Fade_InOut.IsFade);
    }

    public override IEnumerator SlowFadeIn(string sourceName)
    {
        spineCharacter.skeletonDataAsset = dic_characterSprites[sourceName];
        fade_InOut.FadeIn(this, spineCharacter, 0.7f);

        yield return new WaitUntil(() => Fade_InOut.IsFade);
    }

    public override IEnumerator SlowFadeOut()
    {
        fade_InOut.FadeOut(this, spineCharacter, 0.7f);

        yield return new WaitUntil(() => Fade_InOut.IsFade);

        spineCharacter.gameObject.SetActive(false);
    }
}
