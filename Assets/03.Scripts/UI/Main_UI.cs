using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_UI : Scene_UI
{
    [SerializeField] GameObject album_Tab;

    private void Start()
    {
        SceneStart();

        SlotManager.Instance.SaveSlots = saveSlots;

        SlotManager.Instance.Awake();
        SlotManager.Instance.SetDataSlot();
    }

    public void NewGame()
    {
        StoryManager.Instance.IsNewGame = true;
        fade_InOut.MoveScene(this, fade_BackGround, "Play");
    }

    public void OffTool()
    {
        toolTab.gameObject.SetActive(false);
    }

    public void LoadGame()
    {
        SlotManager.Instance.Ingame_LoadBtn(this);

        currentToolText.text = "Load";
        toolTab.gameObject.SetActive(true);
        save_Load_Tab.gameObject.SetActive(true);
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
        option_tab.gameObject.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
