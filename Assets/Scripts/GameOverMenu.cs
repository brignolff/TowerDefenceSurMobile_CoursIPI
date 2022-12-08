using Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

		public void SaveScore()
		{
				string playerName = FindObjectsOfType<GameObject>().First(go => go.name == "NameInput").GetComponent<TMP_InputField>().text;

				HighScoreManager._instance.SaveHighScore(name, Config.Score);

				Config.Score = Config.StartingScore;

				SceneManager.LoadScene(0);
		}
}
