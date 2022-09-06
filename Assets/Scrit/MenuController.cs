using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().Play();
    }
    public void SceneChange()
    {
        SceneManager.LoadScene("Juego");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
