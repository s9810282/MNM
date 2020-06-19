using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] List<string> binary_path = new List<string>();



    public List<string> Binary_Path { get { return binary_path; } set { binary_path = value; } }

    public void SaveBinaryPathToCSV()
    {
        using (var writer = new CSVFileWriter("Assets/Resources/Binary_Path.csv"))
        {
            List<string> columns = new List<string>() { "Count", "Path" };// making Index Row

            writer.WriteRow(columns);
            columns.Clear();

            for(int i = 0;  i < binary_path.Count; i++)
            {
                columns.Add(i.ToString());
                columns.Add(binary_path[i]);

                writer.WriteRow(columns);
                columns.Clear();
            }
        }
    }

    public List<Dictionary<string,string>> LoadCSVData()
    {
        List<Dictionary<string, string>> saveData = new List<Dictionary<string, string>>();
        saveData = CSVReader.Read("Binary_Path.csv");

        return saveData;
    }

    public void LoadBinary()
    {
        List<Dictionary<string, string>> saveData = LoadCSVData();


    }
}
