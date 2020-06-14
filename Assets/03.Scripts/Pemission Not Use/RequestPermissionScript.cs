using UnityEngine;
using UnityEngine.Android;

public class RequestPermissionScript : MonoBehaviour
{
    void Start()
    {
        CheckPermission();
    }

    public void CheckPermission()
    {
        //권한이 있는가?
        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Debug.Log("Get USerPermission");
        }
        else
        {
            //권한 요청
            Permission.RequestUserPermission(Permission.Microphone);
            CheckPermission();
        }
    }
}