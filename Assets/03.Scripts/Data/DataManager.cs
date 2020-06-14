using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class DataManager
{
    //무엇을?         어디에?
    public static void BinarySerialize<T>(T t, string filePath) //저장
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(filePath, FileMode.Create); //파일 스트림 생성 모드
        formatter.Serialize(stream, t); //저장위치에다가 파일을 저장
        stream.Close();
    }
    //     어디서?
    public static T BinaryDeserialize<T>(string filePath) // 불러옴
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(filePath, FileMode.Open);  //파일 스트림 읽기 모드
        T t = (T)formatter.Deserialize(stream); //t에다가 저장위치에 저장되어있는 파일을 불러다가 저장
        stream.Close();
        return t;
    }

}
