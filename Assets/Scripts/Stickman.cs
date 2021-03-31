using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;      
    public static float run = 5f;
    
    private void Update()
    {        
        transform.Translate(new Vector3(1,0,0) * (run * Time.deltaTime));
        if(Time.timeScale == 0)
        {
            Destroy(gameObject);
        }
    }
   
    public void OnDestroy()
    {
        if(Time.timeScale == 1)
        {
            ScoreScript.scoreValue += 1; //score count
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }  
    }
}
