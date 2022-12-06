using Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PathNode_S : MonoBehaviour
{
		[SerializeField]
		Transform NextNode;

		[SerializeField]
		bool IsSpawner;

		[SerializeField]
		bool IsEnd;

		[SerializeField]
		double SpawnInterval;

		Timer spawnTimer;
		bool mustSpawn;

    // Start is called before the first frame update
    void Start()
    {
				spawnTimer = new Timer(SpawnInterval);
				spawnTimer.Elapsed += _SpawnTimer_Elapsed;
    }

		private void _SpawnTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
				mustSpawn = true;
		}

		// Update is called once per frame
		void Update()
    {
        if (IsSpawner && mustSpawn)
				{
						
						mustSpawn = false;
				}
    }

		private void OnTriggerEnter2D(Collider2D collision)
		{
				if (!IsSpawner)
				{
						GameObject collidedObject = collision.gameObject;

						if (collidedObject.tag == Config.OpponentTag)
						{
								if (IsEnd)
								{
										Destroy(collidedObject);
										//could trigger gameover method
								}
								else
								{
										collidedObject.GetComponent<Opponent_S>().NextNodeTransform = NextNode;
								}
						}
				}
		}
}
