using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update

    public bool open = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open(float positionX, float positionZ)
    {
        if(open)
        {
            return;
        }
        transform.position = new Vector3(positionX, -4f,positionZ);
        open = true;
    }

    public void Close(float positionX, float positionZ)
    {
        if(!open)
        {
            return;
        }
        transform.position = new Vector3(positionX, 4.4f, positionZ);
        open = false;
    }
}
