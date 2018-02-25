using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public bool isVertical;
	int toggleMovement = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isVertical) {
			transform.Translate (Vector3.left * Time.deltaTime * toggleMovement);
		} else {
			transform.Translate (Vector3.up * Time.deltaTime * toggleMovement);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals ("Player")) {
			Destroy (collision.gameObject);
			GameController.instance.RestartGame ();
		} else  if (!collision.gameObject.tag.Equals ("enemy")) {
			toggleMovement = toggleMovement * (-1);
		}
	}
}
