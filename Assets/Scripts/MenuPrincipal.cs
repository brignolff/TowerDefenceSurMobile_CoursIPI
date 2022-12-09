using Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
		public Scene GameScene;

		public void Start()
		{
		}


		public void Update()
		{
		}


		public void LauchGame()
		{
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

