using Configuration;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreActuator : MonoBehaviour
{
		TMP_Text scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
				scoreLabel.text = $"Score : {Config.Score}";
    }
}
