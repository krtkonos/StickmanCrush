using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public static int scoreValue = 0;
    [SerializeField] private Text score;
    
    void Start()
    {        
        score = GetComponent<Text>();
    }

    
    void Update()
    {
        scoreValueUpdate();
    }
    
    private void scoreValueUpdate()
    {
        score.text = "Score: " + scoreValue; //show "Score" plus score count
    }
}
