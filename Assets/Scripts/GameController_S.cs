using Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_S : MonoBehaviour
{
		[SerializeField]
		private GameObject Turret;

		// Start is called before the first frame update
		void Start()
    {
				Config.Score = Config.StartingScore;
		}

    // Update is called once per frame
    void Update()
    {
				if (Input.GetMouseButtonDown(0) && Config.Score >= 5)
				{
						Vector3 mousePos = Input.mousePosition;

						mousePos.z = Camera.main.nearClipPlane;
						Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
						Vector2 Worldpos2D = new Vector2(Worldpos.x, Worldpos.y);

						Instantiate(Turret, Worldpos2D, Quaternion.identity);
						Config.Score = Config.Score - 5;
						Console.Write(Config.Score);
				}
		}
}
