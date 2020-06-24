using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class FileList
{
    private static FileList instance;
    public static FileList Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new FileList();
            }

            return instance;
        }
    }

    //바이너리 파일 저장 경로
    Dictionary<int, string> binary_path = new Dictionary<int, string>();
    List<Dictionary<string, string>> saveData = new List<Dictionary<string, string>>();



    public Dictionary<int, string> Binary_Path { get { return binary_path; } set { binary_path = value; } }
    public List<Dictionary<string, string>> SaveData { get { return saveData; } set { saveData = value; } }

    public void SaveBinaryPathToCSV()
    {
        using (var writer = new CSVFileWriter("Assets/Resources/Binary_Path.csv"))
        {
            List<string> columns = new List<string>() { "Count", "Path" };// making Index Row

            writer.WriteRow(columns);
            columns.Clear();

            foreach(var item in binary_path)
            {
                columns.Add(item.Key.ToString());
                columns.Add(item.Value.ToString());

                writer.WriteRow(columns);
                columns.Clear();
            }
        }
    }

    //public List<Dictionary<string,string>> LoadCSVData()
    //{
    //    saveData = new List<Dictionary<string, string>>();
    //    saveData = CSVReader.Read("Binary_Path.csv");

    //    return saveData;
    //}

        
    public void LoadCSVData()
    {
        if (File.Exists("Assets/Resources/Binary_Path.csv"))    
        {
            Debug.Log("Exist");
            saveData = new List<Dictionary<string, string>>();
            saveData = CSVReader.Read("Binary_Path");
        }
    }

    public void LoadBinary()
    {
        //List<Dictionary<string, string>> saveData = LoadCSVData();

        for(int i = 0; i < saveData.Count; i++)
        {
            binary_path.Add(int.Parse(saveData[i]["Count"]), saveData[i]["Path"]);
            Debug.Log(binary_path[int.Parse(saveData[i]["Count"])]);
        }
    }
}
