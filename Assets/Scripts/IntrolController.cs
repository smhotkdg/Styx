using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntrolController : MonoBehaviour
{
    public GameObject Logo;
    bool start = false;
    
    private void Start()
    {
        Logo.SetActive(true);
        
        //StartCoroutine(StartLogoInit());
    }
    IEnumerator StartLogoInit()
    {
        yield return new WaitForSeconds(0.5f);
        LoadLevel("Styx");
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
