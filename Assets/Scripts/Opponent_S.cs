using Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Opponent_S : MonoBehaviour
{
		// Adjust the speed for the application.
		[SerializeField]
		float speed = 1.0f;

		// The target (cylinder) position.
		public Transform NextNodeTransform;

		// Start is called before the first frame update
		void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
				// Move our position a step closer to the target.
				var step = speed * Time.deltaTime; // calculate distance to move
				transform.position = Vector3.MoveTowards(transform.position, NextNodeTransform.position, step);
		}
}
