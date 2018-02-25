using UnityEngine;
using System.Collections;
using System;

public class Bomb : MonoBehaviour
{
    public GameObject fire;
   
    internal int firePower;
    internal float fuse = 2;
	GameController gameController;
    Vector3[] directions = new Vector3[] { Vector3.up, Vector3.down, Vector3.left, Vector3.right };

    // Use this for initialization
    void Start()
    {
        Invoke("Explode", fuse);
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    //Bomb should now explode
    public void Explode()
    {
        //Prevent double 
        CancelInvoke("Explode");

        //Create center fire
        Instantiate(fire, transform.position, Quaternion.identity);

        //create the rest of the fire
		foreach (Vector3 direction in directions)
        {
            SpawnFire(direction);
        }

        //Remove the bomb
        Destroy(gameObject);
    }

    private void SpawnFire(Vector3 offset, int fire = 1)
    {
        //Calculte fire position
        int x = (int)transform.position.x + (int)offset.x * fire;
        int y = (int)transform.position.y + (int)offset.y * fire;

        x = Mathf.Clamp(x, 0, GameController.X - 1);
        y = Mathf.Clamp(y, 0, GameController.Y - 1);

        //If the square is free
        if (gameController.level[x, y] == null && fire < firePower)
        {
            Instantiate(this.fire, transform.position + (offset * fire), Quaternion.identity);
            //Call self, keep spawning fire
            SpawnFire(offset, ++fire);
        }
        else if(fire < firePower)
        {
            //Check if we have hit anything
            if(gameController.level[x, y] != null && gameController.level[x, y].tag == "Destroyable")
            {
                Instantiate(this.fire, transform.position + (offset * fire), Quaternion.identity);
            }
        }  
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        //Turn on bomb collision when player leaves.
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
