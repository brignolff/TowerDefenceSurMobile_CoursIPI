using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using Timer = System.Timers.Timer;

public class Turret_S : MonoBehaviour
{
		const string OpponentTag = "Opponent";

		[SerializeField]
		public float RotationSpeed;

		List<Opponent_S> opponents = new List<Opponent_S>();

		Transform targettedOpponentTransform;

		int targettedOpponentId;

		[SerializeField]
		double SpawnInterval;

		[SerializeField]
		float ProjectileSpeedMultiplier;

		Timer spawnTimer;

		bool mustFire;

		[SerializeField]
		GameObject Projectile;

		// Start is called before the first frame update
		void Start()
		{
				spawnTimer = new Timer(SpawnInterval);

				spawnTimer.Elapsed += _SpawnTimer_Spawn;

				spawnTimer.Start();
		}

		private void _SpawnTimer_Spawn(object sender, ElapsedEventArgs e)
		{
				mustFire = true;
		}

		// Update is called once per frame
		void Update()
    {
				//look at targetted opponent
				if (targettedOpponentTransform != null) 
				{
						//look at targetted opponent
						float angle = Mathf.Atan2(targettedOpponentTransform.position.y - transform.position.y, targettedOpponentTransform.position.x - transform.position.x) * Mathf.Rad2Deg;
						Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
						transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);

						//fire at opponent
						if (mustFire)
						{
								mustFire = false;

								GameObject projectile = (GameObject)Instantiate(Projectile, this.transform.position, Quaternion.Euler(new Vector3(0, 0, angle + 90)));

								float x = targettedOpponentTransform.position.x - transform.position.x;
								float y = targettedOpponentTransform.position.y - transform.position.y;
								projectile.GetComponent<Rigidbody2D>().velocity = new(x * ProjectileSpeedMultiplier, y * ProjectileSpeedMultiplier);
						}
				}
    }

		private void OnTriggerEnter2D(Collider2D collision)
		{
				//detect entering opponent
				if (collision.gameObject.tag == OpponentTag)
				{
						Opponent_S opponent = collision.gameObject.GetComponent<Opponent_S>();
						opponents.Add(opponent);

						//Check if turret should change target
						if (opponents.Count == 1 || opponent.id < targettedOpponentId)
						{
								targettedOpponentId = opponent.id;

								targettedOpponentTransform = collision.gameObject.transform;
						}
				}
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
				//detect exiting opponent
				if (collision.gameObject.tag == OpponentTag)
				{
						Opponent_S opponent = collision.gameObject.GetComponent<Opponent_S>();
						opponents.Remove(opponent);

						//Acquire new target
						if (opponents.Count > 0)
						{
								targettedOpponentId = opponents.Min(opp => opp.id);

								targettedOpponentTransform = opponents.First(opp => opp.id == targettedOpponentId).gameObject.transform;
						}
						else //or not
								targettedOpponentTransform = null;
				}
		}
}
