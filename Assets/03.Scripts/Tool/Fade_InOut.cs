using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Spine.Unity;

public class Fade_InOut
{
    float animtime = 1.5f; //Fade In Out을 몇초동안 실행 시킬건지
    float start;
    float end;
    float time = 0;

    static bool isFadeEnd;
    public static bool IsFadeEnd { get { return isFadeEnd; } set { isFadeEnd = value; } }

    public void FadeIn(MonoBehaviour player, Image fadeObj, float _time = 1.5f, float _start = 1f) 
    {
        animtime = _time;
        player.StartCoroutine(FadeIn(fadeObj, _start));
    }

    public void FadeIn(MonoBehaviour player, Text fadeObj, float _time = 1.5f)
    {
        animtime = _time;
        player.StartCoroutine(FadeIn(fadeObj));
    }

    public void FadeIn(MonoBehaviour player, SkeletonGraphic fadeObj, float _time = 1.5f)  
    {
        animtime = _time;
        player.StartCoroutine(FadeIn(fadeObj));
    }

    public void FadeInFill(MonoBehaviour player, Image fadeObj, float _time = 1f)  
    {
        animtime = _time;
        player.StartCoroutine(FadeInFill(fadeObj));
    }


    public void FadeOut(MonoBehaviour player, Image fadeObj, float _time = 1.5f)  
    {
        animtime = _time;
        player.StartCoroutine(FadeOut(fadeObj));
    }

    public void FadeOut(MonoBehaviour player, Text fadeObj, float _time = 1.5f)
    {
        animtime = _time;
        player.StartCoroutine(FadeOut(fadeObj));
    }

    public void FadeOut(MonoBehaviour player, SkeletonGraphic fadeObj, float _time = 1.5f)  
    {
        animtime = _time;
        player.StartCoroutine(FadeOut(fadeObj));
    }

    public void FadeOutFill(MonoBehaviour player, Image fadeObj, float _time = 1f)  
    {
        animtime = _time;
        player.StartCoroutine(FadeOutFill(fadeObj));

    }


    public void SceneStart(MonoBehaviour player, Image fadeObj, float _time = 1.5f)
    {
        animtime = _time;
        player.StartCoroutine(SceneStart(player, fadeObj));
    }

    public void MoveScene(MonoBehaviour player, Image fadeObj, string name, float waitTime = 1.5f, float _time = 1.5f)
    {
        animtime = _time;

        fadeObj.gameObject.SetActive(true);
        player.StartCoroutine(MoveScene(player, fadeObj, name, waitTime));
    }


    IEnumerator FadeIn(Image fadeobj, float _end = 1)
    {
        isFadeEnd = false;

        float start = 0;
        float end = _end;
        float time = 0;

        Color color = fadeobj.color;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a < _end)
        {
            time += Time.deltaTime / animtime;

            color.a = Mathf.Lerp(start, end, time);

            fadeobj.color = color;

            yield return null;
        }

        isFadeEnd = true;
;
    }  //배경이 나타남

    IEnumerator FadeIn(Text fadeobj)
    {
        isFadeEnd = false;

        float start = 0;
        float end = 1;
        float time = 0;

        Color color = fadeobj.color;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a < 1f)
        {
            time += Time.deltaTime / animtime;

            color.a = Mathf.Lerp(start, end, time);

            fadeobj.color = color;

            yield return null;
        }

        isFadeEnd = true;
        ;
    }


    IEnumerator FadeOut(Image fadeobj)
    {
        isFadeEnd = false ;

        float start = 1;
        float end = 0;
        float time = 0;

        Color color = fadeobj.color;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a > 0f)
        {
            time += Time.deltaTime / animtime;

            color.a = Mathf.Lerp(start, end, time);

            fadeobj.color = color;

            yield return null;
        }

        isFadeEnd = true;

    }  //배경이 사라짐

    IEnumerator FadeOut(Text fadeobj)
    {
        isFadeEnd = false;

        float start = 1;
        float end = 0;
        float time = 0;

        Color color = fadeobj.color;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a > 0f)
        {
            time += Time.deltaTime / animtime;

            color.a = Mathf.Lerp(start, end, time);

            fadeobj.color = color;

            yield return null;
        }

        isFadeEnd = true;

    }  


    IEnumerator FadeInFill(Image fadeobj)
    {
        isFadeEnd = false;

        float start = 0;
        float end = 1;
        float time = 0;

        float aMount = fadeobj.fillAmount;
        aMount = Mathf.Lerp(start, end, time);

        while (aMount < 1f)
        {
            time += Time.deltaTime / animtime;

            aMount = Mathf.Lerp(start, end, time);

            fadeobj.fillAmount = aMount;

            yield return null;
        }

        isFadeEnd = true;
        
    }  //배경이 나타남

    IEnumerator FadeOutFill(Image fadeobj)
    {
        isFadeEnd = false;

        float start = 1;
        float end = 09;
        float time = 0;

        float aMount = fadeobj.fillAmount;
        aMount = Mathf.Lerp(start, end, time);

        while (aMount > 0f)
        {
            time += Time.deltaTime / animtime;

            aMount = Mathf.Lerp(start, end, time);

            fadeobj.fillAmount = aMount;

            yield return null;
        }

        isFadeEnd = true;

    }  //배경이 나


    IEnumerator FadeIn(SkeletonGraphic fadeobj)
    {
        isFadeEnd = false;

        float start = 0;
        float end = 1;
        float time = 0;

        Color color = fadeobj.color;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a < 1f)
        {
            time += Time.deltaTime / animtime;

            color.a = Mathf.Lerp(start, end, time);

            fadeobj.color = color;

            yield return null;
        }

        isFadeEnd = true;
        
    }  //캐릭터가 나타남

    IEnumerator FadeOut(SkeletonGraphic fadeobj)
    {
        isFadeEnd = false;

        float start = 1;
        float end = 0;
        float time = 0;

        Color color = fadeobj.color;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a > 0f)
        {
            time += Time.deltaTime / animtime;

            color.a = Mathf.Lerp(start, end, time);

            fadeobj.color = color;

            yield return null;
        }

        isFadeEnd = true;

    }  //캐릭터가 사라짐



    IEnumerator MoveScene(MonoBehaviour player, Image fadeObj, string name, float waitTime)
    {
        player.StartCoroutine(FadeIn(fadeObj));

        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(name);
    }  //씬을 time만큼 기다린후 name으로 이동

    IEnumerator SceneStart(MonoBehaviour player, Image fadeObj)
    {
        player.StartCoroutine(FadeOut(fadeObj));

        yield return new WaitForSeconds(1.5f);
        fadeObj.gameObject.SetActive(false);
    }

}
