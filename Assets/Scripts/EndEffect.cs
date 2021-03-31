using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEffect : MonoBehaviour
{
    [SerializeField] private float time;
    void Start()
    {
        //destroy
        Destroy(gameObject, time);
    }

    
    
}
