using Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode_S : MonoBehaviour
{
		[SerializeField]
		GameObject NextNode;

		Transform nextNodeTransform;

    // Start is called before the first frame update
    void Start()
    {
				nextNodeTransform = NextNode.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

		private void OnTriggerEnter2D(Collider2D collision)
		{
				if (collision.CompareTag(Config.OpponentTag))
				{
						collision.gameObject.GetComponent<Opponent_S>().NextNodeTransform = nextNodeTransform;
				}
		}
}
