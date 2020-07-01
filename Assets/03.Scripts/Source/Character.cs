using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;


public class Character : StatementOBJ
{
    [SerializeField] SkeletonAnimation skeletonAnimation;

    [SerializeField] SkeletonGraphic spineCharacter;

    [SerializeField] Material clearMaterial;

    [SerializeField] Material skeletonGraphicDefault;


    [SerializeField] string[] characterSpriteName;

    [SerializeField] SkeletonDataAsset[] characterSprites;

    private Dictionary<string, SkeletonDataAsset> dic_characterSprites= new Dictionary<string, SkeletonDataAsset>();

    // Start is called before the first frame update
    void Start()
    {
        SetDelegate();

        for (int i = 0; i < characterSpriteName.Length; i++)
            dic_characterSprites.Add(characterSpriteName[i], characterSprites[i]);

        //SlowlyFadeIn("Girl");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Change(string sourceName)
    {
        spineCharacter.skeletonDataAsset = dic_characterSprites[sourceName];
        spineCharacter.material = skeletonGraphicDefault;
    }

    public override void Delete(string sorceName = null)
    {
        spineCharacter.material = clearMaterial;
        //spineCharacter.skeletonDataAsset = null;
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
        spineCharacter.enabled = false;

        spineCharacter.skeletonDataAsset = dic_characterSprites[sourceName];
        spineCharacter.material = skeletonGraphicDefault;


        fade_InOut.FadeIn(this, spineCharacter, 0.7f);

        yield return new WaitUntil(() => Fade_InOut.IsFade);
        spineCharacter.enabled = true;
    }

    public override IEnumerator SlowFadeOut()
    {
        fade_InOut.FadeOut(this, spineCharacter, 0.7f);

        yield return new WaitUntil(() => Fade_InOut.IsFade);

        spineCharacter.gameObject.SetActive(false);

        spineCharacter.material = clearMaterial;
        //spineCharacter.skeletonDataAsset = null;
    }
}
