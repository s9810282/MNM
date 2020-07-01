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

    [SerializeField] protected GameObject option_tab;

    [SerializeField] protected Image fade_BackGround;

    [Header("Option Slider")]
    [SerializeField] protected Slider mainSoundSlider;
    [SerializeField] protected Slider soundEffectSlider;
    [SerializeField] protected Slider bgmSoundSlider;

    [SerializeField] protected Slider textSpeedSlider;

    [SerializeField] protected RawImage ingameImage;
    [SerializeField] protected Text currentText;

    [Space(3f)]

    [Header("Slots")]
    [SerializeField] protected SaveSlot[] saveSlots;




    protected Fade_InOut fade_InOut;

    void Awake()
    {
        //SlotManager.Instance.SaveSlots();
        Debug.Log(Application.dataPath);
    }

    //Scene Fade Fun
    public void SceneStart()
    {
        fade_InOut = new Fade_InOut();
        fade_InOut.SceneStart(this, fade_BackGround);
    }

    public void MoveScene()
    {
        fade_InOut.MoveScene(this, fade_BackGround, "Play");
    }

    public void MoveScene(string str = "Play")
    {
        fade_InOut.MoveScene(this, fade_BackGround, str);
    }


    //Option Slider Func
    public void MainSoundControl(Slider slider)
    {
        SoundManager.Instance.SoundValue.MainSoundValue = slider.value;
    }

    public void SoundEffectControl(Slider slider)
    { 
        SoundManager.Instance.SoundValue.SoundEffectValue = slider.value;
    }

    public void BGMSoundControl(Slider slider)
    {
        SoundManager.Instance.SoundValue.BgmValue = slider.value;
    }

    public void TextSpeedControl(Slider slider)
    {
        StoryManager.Instance.TextSpeed = slider.value;
    }


    //OnOption Setting
    public virtual void SettingOptionSlider()
    {
        mainSoundSlider.value = SoundManager.Instance.SoundValue.MainSoundValue;
        soundEffectSlider.value = SoundManager.Instance.SoundValue.SoundEffectValue;
        bgmSoundSlider.value = SoundManager.Instance.SoundValue.BgmValue;

        textSpeedSlider.value = StoryManager.Instance.TextSpeed;
    }
}
