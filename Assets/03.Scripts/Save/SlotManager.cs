using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    [SerializeField] SaveSlot[] saveSlots;

    int captureCount = 0;


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
