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

    static bool isFade;
    public static bool IsFade { get { return IsFade; } set { isFade = value; } }

    public void FadeIn(MonoBehaviour player, Image fadeObj, float _time = 1.5f)  //씬을 시작할 때 씬에서 FadeBackGround가 터치를 막으므로 몇초 뒤에 false 시킨다
    {
        animtime = _time;
        player.StartCoroutine(FadeIn(fadeObj));
    }

    public void FadeIn(MonoBehaviour player, SkeletonGraphic fadeObj, float _time = 1.5f)  //씬을 시작할 때 씬에서 FadeBackGround가 터치를 막으므로 몇초 뒤에 false 시킨다
    {
        animtime = _time;
        player.StartCoroutine(FadeIn(fadeObj));
    }

    public void FadeOut(MonoBehaviour player, Image fadeObj, float _time = 1.5f)  //씬을 시작할 때 씬에서 FadeBackGround가 터치를 막으므로 몇초 뒤에 false 시킨다
    {
        animtime = _time;
        player.StartCoroutine(FadeOut(fadeObj));
    }

    public void FadeOut(MonoBehaviour player, SkeletonGraphic fadeObj, float _time = 1.5f)  //씬을 시작할 때 씬에서 FadeBackGround가 터치를 막으므로 몇초 뒤에 false 시킨다
    {
        animtime = _time;
        player.StartCoroutine(FadeOut(fadeObj));
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

    IEnumerator FadeIn(Image fadeobj)
    {
        StoryManager.Instance.IsFadeEnd = false;

        start = 0;
        end = 1;
        time = 0;

        Color color = fadeobj.color;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a < 1f)
        {
            time += Time.deltaTime / animtime;

            color.a = Mathf.Lerp(start, end, time);

            fadeobj.color = color;

            yield return null;
        }

        StoryManager.Instance.IsFadeEnd = true;
;
    }  //배경이 나타남

    IEnumerator FadeOut(Image fadeobj)
    {
        StoryManager.Instance.IsFadeEnd = false ;

        start = 1;
        end = 0;
        time = 0;

        Color color = fadeobj.color;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a > 0f)
        {
            time += Time.deltaTime / animtime;

            color.a = Mathf.Lerp(start, end, time);

            fadeobj.color = color;

            yield return null;
        }

        StoryManager.Instance.IsFadeEnd = true;

    }  //배경이 사라짐

    IEnumerator FadeIn(SkeletonGraphic fadeobj)
    {
        StoryManager.Instance.IsFadeEnd = false;

        start = 0;
        end = 1;
        time = 0;

        Color color = fadeobj.color;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a < 1f)
        {
            time += Time.deltaTime / animtime;

            color.a = Mathf.Lerp(start, end, time);

            fadeobj.color = color;

            yield return null;
        }

        StoryManager.Instance.IsFadeEnd = true;
        ;
    }  //캐릭터가 나타남

    IEnumerator FadeOut(SkeletonGraphic fadeobj)
    {
        StoryManager.Instance.IsFadeEnd = false;

        start = 1;
        end = 0;
        time = 0;

        Color color = fadeobj.color;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a > 0f)
        {
            time += Time.deltaTime / animtime;

            color.a = Mathf.Lerp(start, end, time);

            fadeobj.color = color;

            yield return null;
        }

        StoryManager.Instance.IsFadeEnd = true;

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
