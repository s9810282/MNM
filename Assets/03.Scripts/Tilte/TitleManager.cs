using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Image fadeImage;

    [SerializeField] Image titleImage;

    [SerializeField] VideoPlayer videoPlayer;

    Fade_InOut fade_InOut;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
    }

    // Start is called before the first frame update
    void Start()
    {
        fade_InOut = new Fade_InOut();

        videoPlayer.loopPointReached += OnMovieFinished;

        StartCoroutine(StartTitle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMovieFinished(VideoPlayer player)
    {
        Debug.Log("Event for movie end called");
        StartCoroutine(VideoEnd());
    }


    IEnumerator StartTitle()
    {
        fade_InOut.SceneStart(this, fadeImage);
        yield return new WaitUntil(() => Fade_InOut.IsFade);

        videoPlayer.Play();
    }

    IEnumerator VideoEnd()
    {
        yield return new WaitForSecondsRealtime(1f);
        fade_InOut.MoveScene(this, fadeImage, "Main");
    }
}
