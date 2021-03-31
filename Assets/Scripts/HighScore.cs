using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class HighScore : MonoBehaviour
{
    public static int bestScore;    
    [SerializeField] private Text showedHighScore;

    private void Start()
    {
        showedHighScore.text = "HIGHSCORE: " + GameRoot._Instance._SavingController.MainData._Highscore;
    }
}
