using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Ingame_UI : Scene_UI
{
    #region Instpector

    [Header("ToolBtn")]
    [SerializeField] RectTransform tool_OnBtn;

    [SerializeField] List<RectTransform> tool_Options_Bts;

    [SerializeField] GameObject tool_Btn_Background;

    [SerializeField] float OntargetYPos;

    [SerializeField] float OfftargetYPos;

    [SerializeField] float speed;

    #endregion


    bool isOn = true;

    Vector2 OntargetPos;
    Vector2 OfftargetPos;

    string _path;
    string date;

    Texture2D texture;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SceneStart");
        SceneStart();

        SlotManager.Instance.SaveSlots = saveSlots;
        SlotManager.Instance.SetDataSlot();

        isOn = true;
    }

    public void Ingame_Capture()
    {
        date = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        _path = "_" + date + "_ScreenShot" + ".png";

        //Debug.Log(_path);

        Screenshot.Instance.CaptureDate = date;
        texture = Screenshot.Instance.Return_Capture(this,_path);
    }
    public void OnTool()    
    {
        StartCoroutine(StartOnTool());
    }


    public void OnToolTabs()
    {
        StoryManager.Instance.IsTouchUI = true;
        toolTab.gameObject.SetActive(true);
    }
    public void OffToolTabs()
    {
        StoryManager.Instance.IsTouchUI = false;
        toolTab.gameObject.SetActive(false);
    }


    public void OnSaveTab()
    {
        SlotManager.Instance.Ingame_SaveBtn();

        currentToolText.text = "SAVE";
        save_Load_Tab.gameObject.SetActive(true);
    }
    public void OnLoadTab()
    {
        SlotManager.Instance.Ingame_LoadBtn(this);

        currentToolText.text = "Load";
        save_Load_Tab.gameObject.SetActive(true);
    }


    public void OnOption()
    {
        StoryManager.Instance.IsTouchUI = true;
        option_tab.gameObject.SetActive(true);
    }
    public void OffOption()
    {
        option_tab.gameObject.SetActive(false);
        StoryManager.Instance.IsTouchUI = false;
    }

    public void GoMain()
    {
        MoveScene("Main");
    }


    public override void SettingOptionSlider()
    {
        base.SettingOptionSlider();

        ingameImage.texture = Screenshot.Instance.Texture;
        currentText.text = StoryManager.Instance.ReturnLine("Text");
    }

    IEnumerator StartOnTool()
    {
        WaitForSeconds waitTime = new WaitForSeconds(0.001f);

        //Debug.Log("Tool");

        StoryManager.Instance.IsTouchUI = true;

        if (isOn)
        {
            foreach (var item in tool_Options_Bts)
            {
                OntargetPos = new Vector2(item.anchoredPosition.x, OntargetYPos);

                while (item.anchoredPosition != OntargetPos)
                {
                    item.anchoredPosition = Vector2.MoveTowards(item.anchoredPosition, OntargetPos, Time.deltaTime * speed);
                    yield return waitTime;
                }
            }

            isOn = false;
        }
        else
        {
            tool_Options_Bts.Reverse();

            foreach (var item in tool_Options_Bts)
            {
                OfftargetPos = new Vector2(item.anchoredPosition.x, OfftargetYPos);

                while (item.anchoredPosition != OfftargetPos)
                {
                    item.anchoredPosition = Vector2.MoveTowards(item.anchoredPosition, OfftargetPos, Time.deltaTime * speed);
                    yield return waitTime;
                }
            }

            tool_Options_Bts.Reverse();
            isOn = true;
        }

        StoryManager.Instance.IsTouchUI = false;
    }
}
