using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotManager
{
    private static SlotManager instance;
    public static SlotManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SlotManager();
            }

            return instance;
        }
    }

    private SaveSlot[] saveSlots;
    public SaveSlot[] SaveSlots { get { return saveSlots; } set { saveSlots = value; } }

    public void Awake()
    {
        //시작할 때에 로드 및 세이브창에 데이터를 확인하여 넣어줌
        //메인화면 시작할때도 마찬가지

        FileList.Instance.LoadCSVData();
        FileList.Instance.LoadBinary();
    }

    public void SetDataSlot()
    {
        foreach(var item in FileList.Instance.Binary_Path)
        {
            Debug.Log(item.Key);
            Debug.Log(item.Value);

            saveSlots[item.Key].Load_SetData(item.Value);
        }
    }

    //세이브를 하기 위한 탭 On
    public void Ingame_SaveBtn()
    {
        foreach(var item in saveSlots)
        {
            item.IsSave = true;
        }
    }

    public void Ingame_LoadBtn(Scene_UI scene_UI)
    {
        foreach (var item in saveSlots)
        {
            Debug.Log("item");
            item.IsSave = false;
            item.MoveSceneMethod = new SceneMove(scene_UI.MoveScene);

            //EventTrigger.Entry entry = new EventTrigger.Entry();
            //entry.eventID = EventTriggerType.PointerDown;
            //entry.callback.AddListener((eventdata) => { scene_UI.MoveScene(); });

            //item.GetComponent<EventTrigger>().triggers.Add(entry);

        }
    }
}
