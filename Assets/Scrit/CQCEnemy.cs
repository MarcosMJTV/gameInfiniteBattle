using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CQCEnemy : Enemy
{
    private Color lineColor = Color.white;
    private Vector3 vec;
    private float Speed = 7;
    private int damage = 2;

    void Start()
    {
    }

    void Update()
    {
        vec = new Vector3(Object.transform.position.x, transform.position.y, Object.transform.position.z);
        transform.LookAt(vec);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        transform.position = Vector3.MoveTowards(transform.position, vec, Speed * Time.deltaTime);      
        Debug.DrawLine(transform.position, Object.transform.position, lineColor);
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
            Destroy(gameObject);
        }
    }
}
