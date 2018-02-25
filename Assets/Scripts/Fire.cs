using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    void Start()
    {
        //Remove fire when it's done.
        Destroy(gameObject, 0.3f);
    }

    void Update()
    {
        //Rotate effect
        transform.Rotate(0, 0, -45);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PowerUpSpawner>() != null)
        {
            //Make sure the fire dosn't kill the power up
            GetComponent<CircleCollider2D>().enabled = false;
            other.gameObject.GetComponent<PowerUpSpawner>().SpawnPowerUp();
        }
        //Don't destroy other fires
        else if (other.gameObject.GetComponent<Fire>() != null)
        {
            return;
        }     
        //If we have found a bomb, trigger it
        else if (other.gameObject.GetComponent<Bomb>() != null)
        {
            other.gameObject.GetComponent<Bomb>().Explode();
        }
		//if fire hits the player, game restarts
		if(other.gameObject.tag.Equals("Player"))
			GameController.instance.RestartGame();
        //Remove the thing we collided with.
        Destroy(other.gameObject);
    }
}
