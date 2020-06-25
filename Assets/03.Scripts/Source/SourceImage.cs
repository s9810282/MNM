using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SourceImage : StatementOBJ
{
    [SerializeField] Image sourceImage;

    [SerializeField] string[] sourceImageSpriteName;

    [SerializeField] Sprite[] sourceImagSprites;

    private Dictionary<string, Sprite> dic_sourceImag;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Change(string sourceName)
    {
        sourceImage.sprite = dic_sourceImag[sourceName];
    }

    public override void Delete()
    {
        sourceImage.sprite = null;
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
        StartCoroutine(SlowFadeIn(sourceName));
    }

    public override IEnumerator SlowChange(string sourceName)
    {
        fade_InOut.FadeOut(this, sourceImage);

        yield return new WaitUntil(() => Fade_InOut.IsFade);

        sourceImage.sprite = dic_sourceImag[sourceName];
        fade_InOut.FadeIn(this, sourceImage);

        yield return new WaitUntil(() => Fade_InOut.IsFade);
    }

    public override IEnumerator SlowFadeIn(string sourceName)
    {
        sourceImage.sprite = dic_sourceImag[sourceName];
        fade_InOut.FadeIn(this, sourceImage);

        yield return new WaitUntil(() => Fade_InOut.IsFade);
    }

    public override IEnumerator SlowFadeOut()
    {
        fade_InOut.FadeOut(this, sourceImage);

        yield return new WaitUntil(() => Fade_InOut.IsFade);
    }
}
