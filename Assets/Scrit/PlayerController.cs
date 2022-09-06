using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController player;
    private Animator ani;
    public Score core;
    private Vector3 PlayerVector;
    private Vector3 DirectionMove;
    private float velocityX;
    private float velocityY;
    public float Speed = 20;
    float mim = 0.2f;
    float max = 0.5f;
    public int Life = 3;
    private float saveSpeed;
    private float timer;
    public int speedPlus;
    public int heat = 1;
    public int endurance = 1;

    void Start()
    {
        player = GetComponent<CharacterController>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (Life <= 0) return;
        velocityX = Input.GetAxis("Horizontal");
        velocityY = Input.GetAxis("Vertical");
        PlayerVector = new Vector3(velocityX, 0, velocityY);
        DirectionMove = PlayerVector + transform.position;
        PlayerVector = Vector3.ClampMagnitude(PlayerVector, 1);
        Animation(PlayerVector);
        LookAt();
        player.Move(PlayerVector * (Speed + speedPlus) * Time.deltaTime);
        player.Move(Physics.gravity * Time.deltaTime);
        Endurance();
    }

    public void LookAt()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow) ||
           Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) ||
           Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Joystick1Button2) ||
           Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.Joystick1Button3))
        {
        }
        else
        {
            player.transform.LookAt(DirectionMove);
        }
    }

    private void Animation(Vector3 PlayerVector)
    {
        if (PlayerVector.magnitude > mim && PlayerVector.magnitude < max)
        {
            ani.SetBool("Move", true);
        }
        else if (PlayerVector.magnitude > max)
        {
            ani.SetBool("Move", false);
            ani.SetBool("MoveRunnig", true);
        }
        else
        {
            ani.SetBool("MoveRunnig", false);
            ani.SetBool("Move", false);
        }
    }

    private void Endurance()
    {
        if (heat == 0)
        {
            Life--;
            heat = endurance;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "bullet")
        {
            if (Life > 0)
            {
                if (heat > 0)
                {
                    heat--;
                    Debug.Log("Life: " + Life + ", heat: " + heat);
                }
                else
                {
                    heat = 0;
                }
                
            }
        }
        if (collision.collider.tag == "Enemy")
        {
            if (Life < 0)
            {
                Life = 0;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "life")
        {
            if (Life < 3)
            {
                Life++;
            }
        }
        if (other.tag == "puddle")
        {
            saveSpeed = Speed;
            Speed = Speed * 0.7f;
        }
        if (other.tag == "obstacleDamage" || other.tag == "Damage")
        {
            heat--;
            timer = 0;
        }
        if (other.tag == "itemSpeed")
        {
            if (speedPlus <= 3)
            {
                speedPlus++;
            }
        }
        if (other.tag == "itemShoot")
        {
            if (GetComponent<Fire>().speedPlus <= 9)
            {
                GetComponent<Fire>().speedPlus = GetComponent<Fire>().speedPlus + 3;
            }

        }
        if (other.tag == "itemLife")
        {
            if (endurance <= 3)
            {
                endurance++;
                heat = endurance;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "obstacleDamage" || other.tag == "Damage")
        {
            timer += Time.deltaTime;
            if (timer > 0.7f)
            {
                heat--;
                timer = 0;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "puddle")
        {
            Speed = saveSpeed;
        }
    }
}
