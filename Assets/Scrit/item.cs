using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{   
    void Start()
    {        
    }
   
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
