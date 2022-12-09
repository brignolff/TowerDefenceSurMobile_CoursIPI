using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreLane_S : MonoBehaviour
{
		[SerializeField]
		int scoreId;

    // Start is called before the first frame update
    void Start()
    {
				string text;

				List<Scores> scores = HighScoreManager._instance.GetHighScore();

				if (scoreId <= scores.Count())
				{
						Scores score = scores.ElementAt(scoreId-1);
						text = $"{score.name} : {score.score}";
				}
				else
						text = " ";

				gameObject.GetComponent<TextMeshProUGUI>().text = text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
