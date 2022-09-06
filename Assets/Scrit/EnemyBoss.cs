using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    public List<GameObject> basics = new List<GameObject>();
    public List<GameObject> changes = new List<GameObject>(); 
    private Color lineColor = Color.white;
    private Vector3 vec;
    private float Speed = 10;
    private int danege = 4;
    public int live = 6;
    float timer; 
    void Start()
    {
        foreach (GameObject pount2 in changes)
        {
            pount2.SetActive(false);
        }
    }

 
    void Update()
    {
        vec = new Vector3(Object.transform.position.x, transform.position.y, Object.transform.position.z);
        transform.LookAt(vec);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        moving(vec,Speed);
        Debug.DrawLine(transform.position, Object.transform.position, lineColor);
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            Debug.Log("rady");
            Vector3 vec = new Vector3(Object.transform.position.x,transform.position.y,Object.transform.position.z);
            Assault(vec);
            timer = 0;
        }
        
    }
    private void moving(Vector3 vec, float Speed)
    {
        if (Vector3.Distance(transform.position, Object.transform.position) > 25)
        {
            transform.position = Vector3.MoveTowards(transform.position, vec, Speed * Time.deltaTime);
        }
        else
        {
            //transform.position = Vector3.MoveTowards(transform.position, vec, -Speed * Time.deltaTime);
        }
    }
    private void Assault(Vector3 vec)
    {
        transform.position = Vector3.MoveTowards(transform.position, vec, 50 * Time.deltaTime);
    }

    private void PhaseChange()
    {
        if (live < 4)
        {
            foreach (GameObject pount in basics)
            {
                pount.SetActive(false);
            }

            foreach (GameObject pount2 in changes)
            {
                pount2.SetActive(true);
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!alive)
        {
            return;
        }
        if (collision.collider.tag == "bulletPlayer")
        {
            if (live == 0)
            {
                remove();
            }
            else
            {
                live--;
                PhaseChange();
                Debug.Log(live);
            }
           
        }
        if (collision.collider.tag == "Player")
        {
            Damege(danege);
        }
    }
}
