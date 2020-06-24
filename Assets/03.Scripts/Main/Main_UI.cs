using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_UI : MonoBehaviour
{
    [SerializeField] GameObject toolTab;

    [SerializeField] GameObject save_Load_Tab;

    [SerializeField] GameObject album_Tab;

    [SerializeField] GameObject setting_Tab;

    [SerializeField] Text currentToolText;

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

    public void OffTool()
    {
        toolTab.gameObject.SetActive(false);
    }

    public void LoadGame()
    {
        currentToolText.text = "Load";
        toolTab.gameObject.SetActive(true);
        save_Load_Tab.gameObject.SetActive(true);
    }

    public void MoveScene()
    {
        fade_InOut.MoveScene(this, fade_BackGround, "Play");
    }

    public void Album()
    {
        currentToolText.text = "Album";
        toolTab.gameObject.SetActive(true);
        album_Tab.gameObject.SetActive(true);
    }

    public void Setting()
    {
        currentToolText.text = "Setting";
        toolTab.gameObject.SetActive(true);
        setting_Tab.gameObject.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
