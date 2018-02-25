using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
	// 3 types of power ups
    public int bombs;
    public int firePower;
    public int speed;

    GameController gameController;

    public void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        gameController.level[(int)transform.position.x, (int)transform.position.y] = gameObject;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //See if we have collided with the player
        if (other.gameObject.tag == "Player")
        {
            //Gather references to components
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            BombSpawner BombSpawner = other.gameObject.GetComponent<BombSpawner>();

            //adjust the values
            playerController.speed += speed;
            BombSpawner.numberOfBombs += bombs;
            BombSpawner.firePower += firePower;

            //Remove the powerup
            Destroy(gameObject);
        }
    }
}
