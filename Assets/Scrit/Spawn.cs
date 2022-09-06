using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float Xmax;
    public float Zmax;
    public Vector3 center;
    public int numero = 1;
    public int min;
    public int max;

    
    void Start()
    {
        
        center = transform.position;
        Xmax = GetComponent<BoxCollider>().size.x;
        Zmax = GetComponent<BoxCollider>().size.z;
        

    }

    
    void Update()
    {
        
    }
    
}
