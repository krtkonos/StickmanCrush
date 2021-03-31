using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    public static GameRoot _Instance = null;

    public AdController     _AdController = null;
    public SavingController _SavingController = null;

    private void Awake()
    {
        _Instance = this;

        DontDestroyOnLoad(gameObject);

        _AdController.Init();
        _SavingController.Init();
    }
}
