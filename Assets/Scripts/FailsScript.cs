using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FailsScript : MonoBehaviour
{
    public static int failValue = 0;
    [SerializeField] private Text fail;


    void Start()
    {
        fail = GetComponent<Text>();
    }

    
    void Update()
    {
        failCounting();
    }
    
    private void failCounting()
    {
        fail.text = "Fails " + failValue + "/5"; //Show "Fails" + fail count
    }
    
}
