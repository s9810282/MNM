using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundValue
{
    private float mainSoundValue = 1;
    private float soundEffectValue = 1;
    private float bgmValue = 1;

    public float MainSoundValue { get { return mainSoundValue; } set { mainSoundValue = value; } }
    public float SoundEffectValue { get { return soundEffectValue; } set { soundEffectValue = value; } }
    public float BgmValue { get { return bgmValue; } set { bgmValue = value; } }
}

public class SoundManager
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SoundManager();
                instance.soundValue = new SoundValue();
            }

            return instance;
        }
    }


    private SoundValue soundValue;
    public  SoundValue SoundValue { get { return soundValue; } set { soundValue = value; } }

    public void SoundEffect(MonoBehaviour monoBehaviour,AudioClip audioClip)
    {
        AudioSource audio = monoBehaviour.gameObject.AddComponent<AudioSource>();

        audio.clip = audioClip;
        audio.volume = soundValue.MainSoundValue * soundValue.SoundEffectValue;
        audio.Play();

        UnityEngine.Object.Destroy(audio, audioClip.length);
        //UnityEngine.GameObject.Destroy(audio, audioClip.length);
    }

    public void SetBGM(AudioSource audilSource, AudioClip audioClip)
    {
        audilSource.clip = audioClip;
        audilSource.volume = soundValue.MainSoundValue * soundValue.BgmValue;

        audilSource.Play();
    }
}
