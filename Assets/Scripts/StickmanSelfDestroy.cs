using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanSelfDestroy : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x < -14 || transform.position.x > 14)
        {
            Destroy(transform.gameObject); //Destroy stickman
            FailsScript.failValue += 1; //count Fails
        }
    }
}
