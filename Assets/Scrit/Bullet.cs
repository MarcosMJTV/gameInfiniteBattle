using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject enemy;
    
    void Start()
    {
       
    }

    void Update()
    {
        Destroy(this.gameObject, 6f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Limit") || collision.collider.CompareTag("Door") ||
            collision.collider.tag == "Enemy" || collision.collider.tag == "Player" ||
            collision.collider.tag == "obstacleDamage" || collision.collider.tag == "obstacle")
        {
            Destroy(this.gameObject);
        }
        
    }
    
}
