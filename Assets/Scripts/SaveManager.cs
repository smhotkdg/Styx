using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static SaveManager _instance = null;
    public static SaveManager Instance
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
    public void SaveData(string title,object saveType)
    {
        ES3.Save(title, saveType);
    }
    public void SaveData(string title, string saveType)
    {
        ES3.Save(title, saveType);
    }
    public void SaveData(string title, int saveType)
    {
        ES3.Save(title, saveType);
    }
    public void SaveData(string title, float saveType)
    {
        ES3.Save(title, saveType);
    }
    public void SaveData(string title, bool saveType)
    {
        ES3.Save(title, saveType);

    }
    public object LoadData(string title)
    {
        if (ES3.KeyExists(title))
        {
            return ES3.Load(title);
        }
        return null;
    }
   
}
