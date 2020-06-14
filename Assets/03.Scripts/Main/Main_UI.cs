using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_UI : MonoBehaviour
{
    [SerializeField] GameObject saveFileListLoad;

    [SerializeField] GameObject option;

    [SerializeField] GameObject album;

    [SerializeField] Image fade_BackGround;

    Fade_InOut fade_InOut;

    public void Awake()
    {
        fade_InOut = new Fade_InOut();
        fade_InOut.SceneStart(this, fade_BackGround);
        
    }

    public void NewGame()
    {
        StoryManager.Instance.IsNewGame = true;
        fade_InOut.MoveScene(this, fade_BackGround, "Play");
        //SceneManager.LoadScene("Play");
    }

    public void LoadGame()
    {
        saveFileListLoad.gameObject.SetActive(true);
    }

    public void Album()
    {
        album.gameObject.SetActive(true);
    }

    public void Setting()
    {
        option.gameObject.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
