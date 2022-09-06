using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormEnemy : Enemy
{
    private Color lineColor = Color.white;
    private Vector3 vec;
    private Vector3 ubication;
    public GameObject fire;
    private int danege = 1;
    private Vector3 target;
    float timer;



    void Start()
    {
        InvokeRepeating("changeTarget", 0f, 8f);
        InvokeRepeating("drim", 6f, 8f);
    }

    void Update()
    {


        vec = new Vector3(Object.transform.position.x, transform.position.y, Object.transform.position.z);
        transform.LookAt(vec);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        Debug.DrawLine(transform.position, Object.transform.position, lineColor);

    }

    void changeTarget()
    {

        float x = Random.Range(-20f, 20f);
        float z = Random.Range(-20f, 20f);
        target = new Vector3(spe.center.position.x + x, transform.position.y, spe.center.position.z + z);
        ubication = new Vector3(target.x, 2.4f, target.z);
        transform.position = ubication;
        fire.SetActive(true);

    }
    void drim()
    {
        transform.position = new Vector3(transform.position.x, -1.5f, transform.position.z);
        fire.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!alive)
        {
            return;
        }
        if (collision.collider.tag == "bulletPlayer")
        {
            remove();
        }
        if (collision.collider.tag == "Player")
        {
            Damege(danege);
        }
    }
}
