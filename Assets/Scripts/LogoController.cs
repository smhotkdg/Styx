using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LogoController : MonoBehaviour
{
    public AudioSource audioSource;

    public bool isLoading = true;
    bool start = false;
    bool isMute;
    int L_type = 0;
    public Animator IntroSound;
    public Animator IntroAnim;
    public Text LoadingText;
    public Text InfoText;
    public Text InfoText2;
    public Text TitleText;
    public Text SubTitleText;
    public List<string> TitleTextList;
    public List<string> SubTitleTextList;

    public List<string> LoadingTextList;
    public List<string> InfoTextList;
    void Start()
    {
        if (ES3.KeyExists("StyxBGM"))
        {
            isMute = ES3.Load<bool>("StyxBGM");
            audioSource.mute = !isMute;
        }
        if(ES3.KeyExists("L_Type"))
        {
            L_type = ES3.Load<int>("L_Type");
            switch(L_type)
            {
                case 0:
                    InfoText.text = InfoTextList[0];
                    InfoText2.text = InfoTextList[0];
                    LoadingText.text = LoadingTextList[0];
                    TitleText.text = TitleTextList[0];
                    SubTitleText.text = SubTitleTextList[0];
                    break;
                case 1:
                    InfoText.text = InfoTextList[1];
                    InfoText2.text = InfoTextList[1];
                    LoadingText.text = LoadingTextList[1];
                    TitleText.text = TitleTextList[1];
                    SubTitleText.text = SubTitleTextList[1];
                    break;
                case 2:
                    InfoText.text = InfoTextList[2];
                    InfoText2.text = InfoTextList[2];
                    LoadingText.text = LoadingTextList[2];
                    TitleText.text = TitleTextList[2];
                    SubTitleText.text = SubTitleTextList[2];
                    break;
                case 3:
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case 4:
                    InfoText.text = InfoTextList[4];
                    InfoText2.text = InfoTextList[4];
                    LoadingText.text = LoadingTextList[4];
                    TitleText.text = TitleTextList[4];
                    SubTitleText.text = SubTitleTextList[4];
                    break;
                default:
                    InfoText.text = InfoTextList[1];
                    InfoText2.text = InfoTextList[1];
                    LoadingText.text = LoadingTextList[1];
                    TitleText.text = TitleTextList[1];
                    SubTitleText.text = SubTitleTextList[1];
                    break;
            }
        }
        else
        {
            string code = I2.Loc.LocalizationManager.GetLanguageCode(I2.Loc.LocalizationManager.GetCurrentDeviceLanguage());
            switch (code)
            {
                case "ko":
                    InfoText.text = InfoTextList[0];
                    InfoText2.text = InfoTextList[0];
                    LoadingText.text = LoadingTextList[0];
                    TitleText.text = TitleTextList[0];
                    SubTitleText.text = SubTitleTextList[0];
                    break;
                case "en":
                    InfoText.text = InfoTextList[1];
                    InfoText2.text = InfoTextList[1];
                    LoadingText.text = LoadingTextList[1];
                    TitleText.text = TitleTextList[1];
                    SubTitleText.text = SubTitleTextList[1];
                    break;
                case "ja":
                    InfoText.text = InfoTextList[2];
                    InfoText2.text = InfoTextList[2];
                    LoadingText.text = LoadingTextList[2];
                    TitleText.text = TitleTextList[2];
                    SubTitleText.text = SubTitleTextList[2];
                    break;
                case "es":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-AR":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-BO":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-ES":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-CL":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-CO":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-CR":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-DO":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-EC":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-SV":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-GT":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-HN":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-MX":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-NI":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-PA":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-PY":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-PE":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-PR":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-UY":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-VE":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "es-US":
                    InfoText.text = InfoTextList[3];
                    InfoText2.text = InfoTextList[3];
                    LoadingText.text = LoadingTextList[3];
                    TitleText.text = TitleTextList[3];
                    SubTitleText.text = SubTitleTextList[3];
                    break;
                case "it":
                    InfoText.text = InfoTextList[4];
                    InfoText2.text = InfoTextList[4];
                    LoadingText.text = LoadingTextList[4];
                    TitleText.text = TitleTextList[4];
                    SubTitleText.text = SubTitleTextList[4];
                    break;
                case "it-IT":
                    InfoText.text = InfoTextList[4];
                    InfoText2.text = InfoTextList[4];
                    LoadingText.text = LoadingTextList[4];
                    TitleText.text = TitleTextList[4];
                    SubTitleText.text = SubTitleTextList[4];
                    break;
                default:
                    InfoText.text = InfoTextList[1];
                    InfoText2.text = InfoTextList[1];
                    LoadingText.text = LoadingTextList[1];
                    TitleText.text = TitleTextList[1];
                    SubTitleText.text = SubTitleTextList[1];
                    break;
            }
        }
        StartCoroutine(IntroStartRoutine());
    }
    IEnumerator IntroStartRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        IntroSound.Play("introSoundTitleOff");
        IntroAnim.Play("StyxLogoOn");
    }
    public void PlayBoomSound()
    {
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartLoading()
    {
        if(isLoading)
        {
            StartCoroutine(StartLogoInit());
        }
    }
   
    IEnumerator StartLogoInit()
    {
        yield return new WaitForSeconds(0.1f);
        //LoadLevel("Styx");
        SceneManager.LoadSceneAsync("Styx");
    }
    public void LoadLevel(string nameScene)
    {
        if (start == false)
        {

            StartCoroutine(LoadAsynchronously(nameScene));
            start = true;
        }
    }

    IEnumerator LoadAsynchronously(string nameScen)
    {
        yield return new WaitForSeconds(0.1f);
        AsyncOperation opertation = SceneManager.LoadSceneAsync(nameScen);
        //AsyncOperation opertation =  Application.LoadLevelAsync(0);

        while (!opertation.isDone)
        {

            yield return null;
        }
    }
}
