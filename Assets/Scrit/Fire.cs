using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Bullet;
    private Animator ani;
    private float tiempoEntreDisparos = 0.40f;
    private float tiempoSiguienteDisparo;
    public float speed = 35;
    public int speedPlus;


    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (gameObject.GetComponent<PlayerController>().Life <= 0) return;
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Joystick1Button1)) && Time.time >= tiempoSiguienteDisparo)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
            repetition();
        }
        else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Joystick1Button2)) && Time.time >= tiempoSiguienteDisparo)
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
            repetition();
        }
        else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Joystick1Button0)) && Time.time >= tiempoSiguienteDisparo)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            repetition();
        }
        else if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Joystick1Button3)) && Time.time >= tiempoSiguienteDisparo)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            repetition();
        }
        CloseAnimation();
    }

    public void repetition()
    {
        Vector3 BulletPoin = new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.forward;
        GameObject rgb = Instantiate(Bullet, BulletPoin, Quaternion.identity);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Joystick1Button1))
        {
            ani.SetBool("shoot", true);
            rgb.GetComponent<Rigidbody>().AddForce(Vector3.right * (speed + speedPlus), ForceMode.VelocityChange);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Joystick1Button2))
        {
            ani.SetBool("shoot", true);
            rgb.GetComponent<Rigidbody>().AddForce(Vector3.left * (speed + speedPlus), ForceMode.VelocityChange);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Joystick1Button0))
        {
            ani.SetBool("shoot", true);
            rgb.GetComponent<Rigidbody>().AddForce(Vector3.back * (speed + speedPlus), ForceMode.VelocityChange);
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Joystick1Button3))
        {
            ani.SetBool("shoot", true);
            rgb.GetComponent<Rigidbody>().AddForce(Vector3.forward * (speed + speedPlus), ForceMode.VelocityChange);
        }
        tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
    }

    private void CloseAnimation()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.Joystick1Button1))
        {
            ani.SetBool("shoot", false);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.Joystick1Button2))
        {
            ani.SetBool("shoot", false);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            ani.SetBool("shoot", false);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Joystick1Button3))
        {
            ani.SetBool("shoot", false);
        }
    }
}
