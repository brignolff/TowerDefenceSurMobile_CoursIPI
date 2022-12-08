using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{


    public void Start() 
    {


    }
    
    public void LauchGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SettingSound()
    {
        SceneManager.LoadScene("Option_Menu");

    }

    public void HighScore()
    {
        //TODO List avec highscore, autre sc�ne ? 
    }
}

