using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bullet;
    public Transform player; 
    private float speedShoot;
    private float timer;
    public float speed = 10;
    
    void Start()
    {
        player = GetComponent<Transform>();
        speedShoot = Random.Range(1f, 3f);
    }

    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer >= speedShoot)
        {
            GameObject p = Instantiate(bullet, transform.position, Quaternion.identity);
            p.GetComponent<Rigidbody>().AddForce(transform.forward*speed,ForceMode.Impulse);
            timer = 0;
            speedShoot = Random.Range(1f, 3f);
        }
        
    }
}
