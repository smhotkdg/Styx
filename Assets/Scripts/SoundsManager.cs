using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public List<AudioSource> audioListeners;
    public List<AudioSource> typingAudios;
    public List<AudioSource> knocks;
    public List<AudioSource> sonicbooms;

    public AudioSource MainBGM;
    public AudioSource GunBGM;

    public AudioSource Gun_Init;
    public AudioSource Gun_Shot;
    public AudioSource Gun_Big;

    private static SoundsManager _instance = null;
    private void Start()
    {
        CheckSetting();
    }
    public static SoundsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                return null;
            }
            else
            {
                return _instance;
            }
        }
    }
    private void Awake()
    {
        if (_instance != null)
        {
        }
        else
        {
            _instance = this;
        }
    }
    public enum SoundsType
    {
        normalFoot,
        typing,
        knock,
        booms,
        gunInit,
        gunShot,
        gunBig
    }    
    public void PlayTyping()
    {
        int rand = Random.Range(0, typingAudios.Count);
        typingAudios[rand].Play();
    }
    public void PlaySoundsFx(SoundsType soundsType)
    {
        switch(soundsType)
        {
            case SoundsType.normalFoot:
                audioListeners[(int)soundsType].Play();
                break;
            case SoundsType.typing:
                int rand = Random.Range(0, typingAudios.Count);                                
                typingAudios[rand].Play();
                break;
            case SoundsType.knock:
                int randknock = Random.Range(0, knocks.Count);
                knocks[randknock].Play();
                break;
            case SoundsType.booms:
                int randbooms = Random.Range(0, sonicbooms.Count);
                sonicbooms[randbooms].Play();
                break;
            case SoundsType.gunInit:
                Gun_Init.Play();
                break;
            case SoundsType.gunShot:
                Gun_Shot.Play();
                break;
            case SoundsType.gunBig:
                Gun_Big.Play();
                break;
        }
    }
    public void PlaySonicBooms()
    {
        PlaySoundsFx(SoundsType.booms);
    }
    public void PlayKnock()
    {
        PlaySoundsFx(SoundsType.knock);
    }
    public void PlayGunBGM()
    {
        GunBGM.Play();
        MainBGM.Stop();
    }
    public void PlayMainBGM()
    {
        GunBGM.Stop();
        MainBGM.Play();
    }
    public void CheckSetting()
    {
        for (int i = 0; i < audioListeners.Count; i++)
        {
            audioListeners[i].mute = !GameManager.Instance.data.FX;
        }
        for (int i = 0; i < typingAudios.Count; i++)
        {
            typingAudios[i].mute = !GameManager.Instance.data.FX;
        }
        for (int i = 0; i < knocks.Count; i++)
        {
            knocks[i].mute = !GameManager.Instance.data.FX;
        }
        for (int i = 0; i < sonicbooms.Count; i++)
        {
            sonicbooms[i].mute = !GameManager.Instance.data.FX;
        }
        MainBGM.mute = !GameManager.Instance.data.BGM;

        GunBGM.mute = !GameManager.Instance.data.BGM;
        Gun_Init.mute = !GameManager.Instance.data.FX;
        Gun_Shot.mute = !GameManager.Instance.data.FX;
        Gun_Big.mute = !GameManager.Instance.data.FX;

    GameManager.Instance.SaveData();
    }
}
