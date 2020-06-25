using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_UI : MonoBehaviour
{
    [Header("ToolTab")]

    [SerializeField] protected Text currentToolText;

    [SerializeField] protected GameObject toolTab;

    [SerializeField] protected GameObject save_Load_Tab;

    [SerializeField] protected GameObject setting_Tab;

    [SerializeField] protected Image fade_BackGround;

    [Space(3f)]

    [SerializeField] protected SaveSlot[] saveSlots;




    protected Fade_InOut fade_InOut;

    void Awake()
    {
        //SlotManager.Instance.SaveSlots();
    }

    public void SceneStart()
    {
        fade_InOut = new Fade_InOut();
        fade_InOut.SceneStart(this, fade_BackGround);
    }

    public void MoveScene()
    {
        fade_InOut.MoveScene(this, fade_BackGround, "Play");
    }
}
