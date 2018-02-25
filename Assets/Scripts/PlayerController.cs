using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour{
    public float speed;
    private Rigidbody2D rigidBody2d;

	public int playerNumber = 1;
    public Sprite[] sprites;
    public Vector3[] spawnPositions;

	// Use this for initialization
	void Start () {
        rigidBody2d = GetComponent<Rigidbody2D>();
        GameObject.Find("GameController").GetComponent<GameController>().LevelScan();
        GetComponent<SpriteRenderer>().sprite = sprites[playerNumber - 1];
        transform.position = spawnPositions[playerNumber - 1];
	}

    // Update is called once per frame
    void Update () {

        //Get input from player
		float x = Input.GetAxisRaw("Horizontal_P" + playerNumber);
		float y = Input.GetAxisRaw("Vertical_P" + playerNumber);

        //prevent diagonal movement
        if (Mathf.Abs(x) >= Mathf.Abs(y))
            y = 0;
        else if (Mathf.Abs(y) >= Mathf.Abs(x))
            x = 0;

        //Calculate movement
        Vector2 movement = new Vector2(x, y) * speed;

        //Set movement
        rigidBody2d.velocity = movement;
	}
}
