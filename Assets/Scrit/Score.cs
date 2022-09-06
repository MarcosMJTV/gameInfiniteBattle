using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text text;
    public Text text2;
    public List<GameObject> listEndurance = new List<GameObject>();
    public List<GameObject> listSpeed = new List<GameObject>();
    public List<GameObject> listVelocity = new List<GameObject>();
    public PlayerController player;
    public GameObject mapping;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public Image screen;
    private int count;
    public int waves;
    public int rooms = 1;
    private float screenValore ;
    float AlphaValore;
    
    void Start()
    {
       
    }
  
    void Update()
    {
        text.text = "Waves = " + waves.ToString();
        text2.text = "Life = ";
        count = player.Life;
        Heart(count);
        endurance(listEndurance);
        Speed(listSpeed);
        Velocity(listVelocity);
    }
    
    private void Heart(int count)
    {
        if (count == 3)
        {
            image1.SetActive(true);
        }
        if (count < 3)
        {
            image1.SetActive(false);
            image2.SetActive(true);
        }
        if (count < 2)
        {
            image2.SetActive(false);       
        }      
        if (count == 0)
        {   
            screenValore = 1;    
        }     
    }
    private void endurance(List<GameObject> listEndurance)
    {
        if (player.endurance == 4)
        {
            listEndurance[3].SetActive(true);
        }
        else if (player.endurance == 3)
        {
            listEndurance[2].SetActive(true);
            listEndurance[3].SetActive(false);
        }
        else if (player.endurance == 2)
        {
            listEndurance[1].SetActive(true);
            listEndurance[2].SetActive(false);
            listEndurance[3].SetActive(false);
        }
        else 
        {
            listEndurance[1].SetActive(false);
            listEndurance[2].SetActive(false);
            listEndurance[3].SetActive(false);
        }
    }

    private void Speed(List<GameObject> listSpeed)
    {
        if (player.speedPlus == 3)
        {
            listSpeed[2].SetActive(true);
        }
        else if (player.speedPlus == 2)
        {
            listSpeed[1].SetActive(true);
            listSpeed[2].SetActive(false);
        }
        else if (player.speedPlus == 1)
        {
            listSpeed[0].SetActive(true);
            listSpeed[1].SetActive(false);
            listSpeed[2].SetActive(false);
        }
        else
        {
            listSpeed[0].SetActive(false);
            listSpeed[1].SetActive(false);
            listSpeed[2].SetActive(false);
        }
    }

    private void Velocity(List<GameObject> listVelocity)
    {
        if (player.GetComponent<Fire>().speedPlus == 9)
        {
            listVelocity[2].SetActive(true);
        }
        else if (player.GetComponent<Fire>().speedPlus == 6)
        {
            listVelocity[1].SetActive(true);
            listVelocity[2].SetActive(false);
        }
        else if (player.GetComponent<Fire>().speedPlus == 3)
        {
            listVelocity[0].SetActive(true);
            listVelocity[1].SetActive(false);
            listVelocity[2].SetActive(false);
        }
        else
        {
            listVelocity[0].SetActive(false);
            listVelocity[1].SetActive(false);
            listVelocity[2].SetActive(false);
        }
    }
    private void FixedUpdate()
    {      
        AlphaValore = Mathf.Lerp(screen.color.a, screenValore, .03f);
        screen.color = new Color(253, 253, 253, AlphaValore);
        if (AlphaValore > 0.9f && screenValore == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
