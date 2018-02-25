using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public bool isVertical;  // for direction of enemy movement
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
		// if enemy hits the player or power-ups, it will be destroyed
		if (collision.gameObject.tag.Equals ("Player") || collision.gameObject.tag.Equals ("PowerUp")) {
			Destroy (collision.gameObject);
			if (collision.gameObject.tag.Equals ("Player"))
				GameController.instance.RestartGame ();
		} else  if (!collision.gameObject.tag.Equals ("enemy")) { // do nothing if enemy collides with enemy & change movement if it hit wall or box
			toggleMovement = toggleMovement * (-1);
		}
	}
}
