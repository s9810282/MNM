using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Ingame_UI : MonoBehaviour
{
    #region Instpector

    [Header("ToolBtn")]
    [SerializeField] RectTransform tool_OnBtn;

    [SerializeField] List<RectTransform> tool_Options_Bts;

    [SerializeField] GameObject tool_Btn_Background;

    [SerializeField] float OntargetYPos;

    [SerializeField] float OfftargetYPos;

    [SerializeField] float speed;

    [Space(3f)]

    [Header("ToolTab")]

    [SerializeField] Text currentToolText;

    [SerializeField] GameObject toolTab;

    [SerializeField] GameObject save_Load_Tab;


    [SerializeField] 
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
        isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ingame_Capture()
    {
        date = DateTime.Now.ToString("yyyyMMddHHmmss");
        _path = "_" + date + "_ScreenShot" + ".png";

        Debug.Log(_path);

        Screenshot.Instance.CaptureDate = date;
        texture = Screenshot.Instance.Return_Capture(this,_path);
    }

    public void OnTool()
    {
        StartCoroutine(StartOnTool());
    }

    public void OnToolTabs()
    {
        toolTab.gameObject.SetActive(true);
        PlayerPrefs.Save();
    }


    public void OnSaveTab()
    {
        currentToolText.text = "SAVE";

        save_Load_Tab.gameObject.SetActive(true);
    }

    IEnumerator StartOnTool()
    {
        WaitForSeconds waitTime = new WaitForSeconds(0.001f);

        Debug.Log("Tool");

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
