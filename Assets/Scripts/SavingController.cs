using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum SaveType
{
    MainData,
    OptionsData,
}

public class SavingController : MonoBehaviour
{
    private const string MAIN_DATA = "Maindata.json";
    private const string OPTIONS_DATA = "Options.json";
    private const string FIRST_CRYPT_KEY = "8^$5f*(Wh/-@3M!8";
    private const string SECOND_CRYPT_KEY = "+=1JK)p#h%t8;7{]";

    private MainData _Data = null;
    public MainData MainData
    {
        get { return _Data; }
    }

    private OptionsData _OptionsData = null;
    public OptionsData OptionsData
    {
        get { return _OptionsData; }
    }

    public void Init()
    {
        _Data = TryLoadData();

        if(_Data == null)
        {
            _Data = new MainData();
            TrySaveData(SaveType.MainData);
        }

        _OptionsData = TryLoadOptionsData();

        if (_OptionsData == null)
        {
            _OptionsData = new OptionsData();
            TrySaveData(SaveType.OptionsData);
        }
    }

    private MainData TryLoadData()
    {
        string mainData = LoadData(GetFileName(SaveType.MainData));

        if (string.IsNullOrEmpty(mainData)) return null;

        MainData data = null;
        try
        {
            mainData = Crypt.GetDecrypted(mainData, FIRST_CRYPT_KEY, SECOND_CRYPT_KEY);
            data = JsonUtility.FromJson<MainData>(mainData);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }

        return data;
    }

    private OptionsData TryLoadOptionsData()
    {
        string optionsData = LoadData(GetFileName(SaveType.OptionsData));

        if (string.IsNullOrEmpty(optionsData)) return null;

        OptionsData data = null;
        try
        {
            optionsData = Crypt.GetDecrypted(optionsData, FIRST_CRYPT_KEY, SECOND_CRYPT_KEY);
            data = JsonUtility.FromJson<OptionsData>(optionsData);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }

        return data;
    }

    public void TrySaveData(SaveType pSaveType)
    {
        string fileName = GetFileName(pSaveType);

        string content = "";

        switch (pSaveType)
        {
            case SaveType.MainData:
                content = JsonUtility.ToJson(_Data);
                break;
            case SaveType.OptionsData:
                content = JsonUtility.ToJson(_OptionsData);
                break;
        }

        content = Crypt.GetCrypted(content, FIRST_CRYPT_KEY, SECOND_CRYPT_KEY);
        SaveData(fileName, content);
    }

    private void SaveData(string pFileName, string pOutput)
    {
        string path = GetPath(pFileName);
        File.WriteAllText(path, pOutput);
    }

    private string LoadData(string pFileName)
    {
        string path = GetPath(pFileName);
        string data = string.Empty;
        if (File.Exists(path))
        {
            data = File.ReadAllText(path);
        }

        return data;
    }

    private string GetPath(string pFileName)
    {
        string dirPath = null;
        #if UNITY_EDITOR
                dirPath = Path.Combine(Application.dataPath, "StreamingAssetsEditor");
        #else
        dirPath = Application.persistentDataPath;
        #endif
        if (!Directory.Exists(dirPath))
            Directory.CreateDirectory(dirPath);
        return Path.Combine(dirPath, pFileName);
    }

    private string GetFileName(SaveType pSaveType)
    {
        string fileName = "";

        switch (pSaveType)
        {
            case SaveType.MainData:
                fileName = MAIN_DATA;
                break;
            case SaveType.OptionsData:
                fileName = OPTIONS_DATA;
                break;
        }

        return fileName;
    }
}

[Serializable]
public class MainData
{
    public float  _GamePlayTime;
    public int    _Highscore;
}

[Serializable]
public class OptionsData
{
    public bool             _MusicMuted;
    public float            _MusicVolume;
    public int              _GraphicsQuality = 1;

    public OptionsData()
    {
        _MusicMuted = false;
        _MusicVolume = 1f;
    }
}
