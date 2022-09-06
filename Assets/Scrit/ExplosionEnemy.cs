using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnemy : Enemy
{
    private Color lineColor = Color.white;
    private Vector3 vec;
    private float Speed = 2;
    private Vector3 target;
    private int damage;
    public

    void Start()
    {
        InvokeRepeating("changeTarget", 0, 6f);
    }

    void changeTarget()
    {
        float x = Random.Range(-10f, 10f);
        float z = Random.Range(-10f, 10f);
        target = new Vector3(spe.center.position.x + x, transform.position.y, spe.center.position.z + z);
    }

    void Update()
    {
        Collision(Speed);
        vec = new Vector3(target.x, transform.position.y, target.z);
        transform.LookAt(vec);
        transform.position = Vector3.MoveTowards(transform.position, vec, Speed * Time.deltaTime);
        Debug.DrawLine(transform.position, target, lineColor);
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
            Damege(damage);
        }
    }
}
