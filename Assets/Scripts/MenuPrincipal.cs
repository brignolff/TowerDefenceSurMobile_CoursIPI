using Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public Scene GameScene;
    //public Camera Camera_Menu;
    //public Camera Camera_Game;



    public void Start()
    {

            
            //Camera_Menu.enabled = true;
            //Camera_Game.enabled = false;
            Button Button = gameObject.GetComponent<Button>();
            Button.onClick.AddListener(baz);
        
    }
    void baz()
    {
        //Camera_Menu.enabled = !Camera_Menu.enabled;
        //Camera_Game.enabled = !Camera_Game.enabled;
    }
    

    public void Update()
    {
    

    }

       
    public void LauchGame()
    {

				//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

				Config.Score = Config.StartingScore;
               SceneManager.LoadScene(1);

                
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SettingSound()
    {
        SceneManager.LoadScene(4);
    }

    public void HighScore()
    {
        SceneManager.LoadScene(2);
    }
}

