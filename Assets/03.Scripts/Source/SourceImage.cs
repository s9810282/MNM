using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SourceImage : StatementOBJ
{
    [SerializeField] Image sourceImage;

    [SerializeField] string[] sourceImageSpriteName;

    [SerializeField] Sprite[] sourceImagSprites;

    [SerializeField] Sprite clearImage;

    private Dictionary<string, Sprite> dic_sourceImag = new Dictionary<string, Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        SetDelegate();

        for (int i = 0; i < sourceImageSpriteName.Length; i++)
            dic_sourceImag.Add(sourceImageSpriteName[i], sourceImagSprites[i]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Change(string sourceName)
    {
        Vector2 size = new Vector2(dic_sourceImag[sourceName].rect.width, dic_sourceImag[sourceName].rect.height);
        sourceImage.GetComponent<RectTransform>().sizeDelta = size;

        sourceImage.sprite = dic_sourceImag[sourceName];
    }

    public override void Delete(string sorceName = null)
    {
        sourceImage.sprite = clearImage;
    }

    public override void SlowlyChange(string sourceName)
    {
        Debug.Log("Slowly change");
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
        Vector2 size = new Vector2(dic_sourceImag[sourceName].rect.width, dic_sourceImag[sourceName].rect.height);
        sourceImage.GetComponent<RectTransform>().sizeDelta = size;
        sourceImage.sprite = dic_sourceImag[sourceName];

        fade_InOut.FadeIn(this, sourceImage);
      
        yield return new WaitUntil(() => Fade_InOut.IsFadeEnd);

        fade_InOut.FadeOut(this, sourceImage);

        yield return new WaitUntil(() => Fade_InOut.IsFadeEnd);
    }

    public override IEnumerator SlowFadeIn(string sourceName)
    {
        Vector2 size = new Vector2(dic_sourceImag[sourceName].rect.width, dic_sourceImag[sourceName].rect.height);
        sourceImage.GetComponent<RectTransform>().sizeDelta = size;

        sourceImage.sprite = dic_sourceImag[sourceName];
        fade_InOut.FadeIn(this, sourceImage);

        yield return new WaitUntil(() => Fade_InOut.IsFadeEnd);
    }

    public override IEnumerator SlowFadeOut()
    {
        fade_InOut.FadeOut(this, sourceImage);

        yield return new WaitUntil(() => Fade_InOut.IsFadeEnd);

        sourceImage.sprite = clearImage;
    }
}
