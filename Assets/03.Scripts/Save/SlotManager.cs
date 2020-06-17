using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    [SerializeField] SaveSlot[] saveSlots;

    int captureCount = 0;

    private void Awake()
    {
        //시작할 때에 로드 및 세이브창에 데이터를 확인하여 넣어줌
        //메인화면 시작할때도 마찬가지
    }

    //세이브를 하기 위한 탭 On
    public void Ingame_SaveBtn()
    {
        foreach(var item in saveSlots)
        {
            item.IsSave = true;
        }
    }

    public void Ingame_LoadBtn()
    {
        foreach (var item in saveSlots)
        {
            item.IsSave = false;
        }
    }
}
