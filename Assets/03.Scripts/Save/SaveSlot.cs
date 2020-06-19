using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    [SerializeField] GameObject data_slot;

    [SerializeField] GameObject noData_Slot;

    [SerializeField] int dataCount;

    [Header("Slot Component")]

    [SerializeField] RawImage image;

    [SerializeField] Text scriptText;

    [SerializeField] Text dateText;

    [SerializeField] Text playTimeText;


    [SerializeField] Button delete_Btn;



    [SerializeField] SaveData _saveData;
    public SaveData _SaveData { get { return _saveData; } set { _saveData = value; } }

    private bool isSave;
    public bool IsSave { get { return isSave; } set { isSave = value; } }

    string _path;


    // Start is called before the first frame update
    void Start()
    {
        isSave = true;
        delete_Btn.onClick.AddListener(DeleteData);

        _path = "/" + dataCount + "_data.dat";



    }

    //데이터를 Delete
    public void DeleteData()
    {
        image.texture = null;
        image.color = new Color(185, 185, 185, 255);
        
        scriptText.text = null;
        dateText.text = null;
        playTimeText.text = null;

        _saveData = null;

        FileList.Instance.Binary_Path.Remove(Application.persistentDataPath + _path);
        FileList.Instance.SaveBinaryPathToCSV();
        File.Delete(Application.persistlentDataPath + _path);

        UnityEditor.AssetDatabase.Refresh();

        data_slot.gameObject.SetActive(false);
        noData_Slot.gameObject.SetActive(true);
    }
    //SaveData의 데이터를 슬롯에다가 적용
    public void ApplyData()
    {
        //_SaveData = new SaveData(Screenshot.Instance.DataPath, StoryManager.Instance.FileName
        //   , StoryManager.Instance.CurrentLine);

        _saveData.captureImagePath = Screenshot.Instance.DataPath;
        _saveData.csvFileName = StoryManager.Instance.FileName;
        _SaveData.csvFileLine = StoryManager.Instance.CurrentLine;

        GameDataManager.Instance.Save(_SaveData, _path);

        FileList.Instance.Binary_Path.Add(Application.persistentDataPath + _path);
        FileList.Instance.SaveBinaryPathToCSV();

        Debug.Log(Application.persistentDataPath + _path);

        image.texture = Screenshot.Instance.Texture;
        dateText.text = Screenshot.Instance.CaptureDate;
        scriptText.text = StoryManager.Instance.ReturnLine("Text");

        noData_Slot.gameObject.SetActive(false);
        data_slot.gameObject.SetActive(true);
    }

    //데이터를 Load
    public SaveData Load_Data()
    {
        return _saveData;
    }
}
