using Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Opponent_S : MonoBehaviour
{
	// Adjust the mouvement speed.
	[SerializeField]
	float speed = 1.0f;

	// The target position.
	public Transform NextNodeTransform;
	public GameObject Turret;

	[SerializeField]
	AudioClip audioImpact;

	public int id;

	private static int _id;

	// Start is called before the first frame update
	void Start()
	{
		id = _id++;
	}

	// Update is called once per frame
	void Update()
	{
		// Move our position a step closer to the target.
		var step = speed * Time.deltaTime; // calculate distance to move
		transform.position = Vector3.MoveTowards(transform.position, NextNodeTransform.position, step);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == Config.ProjectileTag)
		{
			AudioSource.PlayClipAtPoint(audioImpact, this.transform.position,Config.SoundLevel);

			Destroy(collision.gameObject);
			Destroy(gameObject);

			Config.Score++;
		}
	}
}
