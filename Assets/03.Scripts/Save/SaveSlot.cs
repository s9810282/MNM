using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public delegate void SceneMove();

public class SaveSlot : MonoBehaviour
{
    [SerializeField] GameObject data_slot;

    [SerializeField] GameObject noData_Slot;

    [SerializeField] int dataCount;

    [SerializeField] Image test;

    [Header("Slot Component")]

    [SerializeField] RawImage image;

    [SerializeField] Text scriptText;

    [SerializeField] Text dateText;

    [SerializeField] Text playTimeText;


    [SerializeField] Button delete_Btn;



    [SerializeField] SaveData _saveData;
    

    private bool isSave;
    private bool isLoad = false;

    string _path;

    private SceneMove moveSceneMethod;

    public bool IsSave { get { return isSave; } set { isSave = value; } }
    public SaveData _SaveData { get { return _saveData; } set { _saveData = value; } }
    public SceneMove MoveSceneMethod { get { return moveSceneMethod; } set { moveSceneMethod = value; } }

    // Start is called before the first frame update
    void Start()
    {
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

        FileList.Instance.Binary_Path.Remove(dataCount);
        FileList.Instance.SaveBinaryPathToCSV();
        File.Delete(Application.persistentDataPath + _path);

        //UnityEditor.AssetDatabase.Refresh();

        data_slot.gameObject.SetActive(false);
        noData_Slot.gameObject.SetActive(true);
    }

    //데이터를 Load하여 슬롯이 가지고 있게 함
    public void Load_SetData(string dataPath)
    {
        isLoad = true;

        _saveData = GameDataManager.Instance.Load(_saveData, dataPath);

        image.texture = Screenshot.Instance.GetPhoto(_saveData.captureImagePath);
        dateText.text = _saveData.saveDate;
        scriptText.text = StoryManager.Instance.ReturnLoadLine(_SaveData.csvFileName, "Text", _SaveData.csvFileLine);

        noData_Slot.gameObject.SetActive(false);
        data_slot.gameObject.SetActive(true);


    }

    public void PressButton()
    {
        Debug.Log(IsSave);

        if (isSave)
            ApplyData();
        else
            Load_Data();
    }

    //SaveData의 데이터를 슬롯에다가 적용
    public void ApplyData()
    {

        if (File.Exists(Application.persistentDataPath + _path))
            File.Delete(Application.persistentDataPath + _path);

        if (File.Exists(_saveData.captureImagePath))
            File.Delete(_saveData.captureImagePath);


        _saveData.captureImagePath = Screenshot.Instance.DataPath;
        _saveData.csvFileName = StoryManager.Instance.FileName;
        _SaveData.csvFileLine = StoryManager.Instance.CurrentLine;
        _SaveData.csvFileNum = StoryManager.Instance.FileNum;


        FileList.Instance.Binary_Path.Remove(dataCount);
        FileList.Instance.Binary_Path.Add(dataCount, Application.persistentDataPath + _path);


        FileList.Instance.SaveBinaryPathToCSV();


        GameDataManager.Instance.Save(_saveData, _path);

        Debug.Log(Application.persistentDataPath + _path);

        image.texture = Screenshot.Instance.Texture;
        dateText.text = Screenshot.Instance.CaptureDate;
        scriptText.text = StoryManager.Instance.ReturnLine("Text");

        noData_Slot.gameObject.SetActive(false);
        data_slot.gameObject.SetActive(true);

    }

    //Load버튼을 통해 Load하여 시작
    //이 함수와 더불어 Ingame_UI의 함수를 통하여 Scene무브를 담당
    public void Load_Data()
    {
        if (!isLoad)
            return;


        StoryManager.Instance.IsNewGame = false;

        StoryManager.Instance.FileName = _saveData.csvFileName;
        StoryManager.Instance.FileNum = _saveData.csvFileNum;
        StoryManager.Instance.CurrentLine = _saveData.csvFileLine;

        moveSceneMethod.Invoke();
    }
}
