using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFire : MonoBehaviour
{
    public GameObject bullet;
    public Transform player;
    private float speedShoot;
    private float timer;
    private float speed = 10;
    public int bullets = 20;
    public int degrees = 360;
    private AudioSource asour;
    public float min = 3f;
    public float max= 8f;

    void Start()
    {
        asour = GetComponent<AudioSource>();
        player = GetComponent<Transform>();
        speedShoot = Random.Range(min, max);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= speedShoot)
        {
            explode();
            timer = 0;
            speedShoot = Random.Range(min, max);
        }
    }

    void explode()
    {
        //asour.Play();
        float angle = degrees / bullets;
        for (int i = 0; i < bullets/2; i++)
        {
            GameObject p = Instantiate(bullet, transform.position, Quaternion.identity);
            p.GetComponent<Rigidbody>().AddForce(Quaternion.Euler(0, angle * i, 0) * transform.forward * speed, ForceMode.VelocityChange);
        }
        for (int i = 0; i < bullets/2; i++)
        {
            GameObject p = Instantiate(bullet, transform.position, Quaternion.identity);
            p.GetComponent<Rigidbody>().AddForce(Quaternion.Euler(0, -angle * i, 0) * transform.forward * speed, ForceMode.VelocityChange);
        }
    }
}
