using Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

		public void SoundLevelChanged(float value)
		{
				Config.SoundLevel = value;
		}

		public void SaveSettings()
		{
				SceneManager.LoadScene(0);
		}
}
