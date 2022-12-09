using Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathNode_S : MonoBehaviour
{
		[SerializeField]
		Transform NextNode;

		[SerializeField]
		bool IsEnd;

		[SerializeField]
		bool IsSpawner;

		double SpawnInterval;

		[SerializeField]
		GameObject SpawnedObject;

		Timer spawnTimer;
		bool mustSpawn;

		Timer DifficultyIncreaseTimer;

		// Start is called before the first frame update
		void Start()
    {
				if (IsSpawner)
				{
						SpawnInterval = Config.StartingSpawnInterval;

						spawnTimer = new Timer(SpawnInterval);
						spawnTimer.Elapsed += _SpawnTimer_Elapsed;

						spawnTimer.Start();

						DifficultyIncreaseTimer = new(Config.DifficultyIncreaseInterval);
						DifficultyIncreaseTimer.Elapsed += _DifficultyIncreaseTimer_Elapsed;

						DifficultyIncreaseTimer.Start();
				}
    }

		private void _DifficultyIncreaseTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
				double reduction;

				if (SpawnInterval <= Config.SpawnIntervalReductionPerDifficultyIncrease)
				{
						reduction = Config.DifficultyIncreaseInterval/Config.StartingSpawnInterval * SpawnInterval;
				}
				else
				{
						reduction = Config.SpawnIntervalReductionPerDifficultyIncrease;
				}

				SpawnInterval -= reduction;

				spawnTimer.Stop();
				spawnTimer.Interval = SpawnInterval;
				spawnTimer.Start();
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
						GameObject opponent = Instantiate(SpawnedObject, this.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
						opponent.GetComponent<Opponent_S>().NextNodeTransform = NextNode;
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
										SceneManager.LoadScene(3);
								}
								else
								{
										collidedObject.GetComponent<Opponent_S>().NextNodeTransform = NextNode;
								}
						}
				}
		}
}
