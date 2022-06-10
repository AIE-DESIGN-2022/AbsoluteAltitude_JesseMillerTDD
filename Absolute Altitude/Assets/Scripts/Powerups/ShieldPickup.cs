using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : MonoBehaviour
{

    void Start()
    {
        
        
    }

    void Update()
    {
     
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<HealthManager>().TurnShieldOn();
            Destroy(gameObject);
        }
    }
}