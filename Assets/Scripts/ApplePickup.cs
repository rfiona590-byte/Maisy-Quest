using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePickup : MonoBehaviour
{
    private void Start()
    {
            
    }

    private void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            MaisyHealth.appleTrue = true;
            //Debug.Log("test");
        }
        
    }
    
}
