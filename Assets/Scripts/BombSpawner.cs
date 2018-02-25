using UnityEngine;
using System.Collections;

public class BombSpawner : MonoBehaviour{

    public GameObject bomb;
    public int firePower = 1;
    public int numberOfBombs = 1;
    public float fuse = 2;
	[SerializeField] PlayerController player;

	void Update () {
		if (Input.GetButtonDown("Fire_P" + player.playerNumber) && numberOfBombs >= 1) {
            SpawnBomb();
        }
    }

    private void SpawnBomb()
    {
        Vector2 spawnPos = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
		GameObject newBomb = Instantiate(bomb, spawnPos, Quaternion.identity) as GameObject;
        newBomb.GetComponent<Bomb>().firePower = firePower;
        newBomb.GetComponent<Bomb>().fuse = fuse;
        numberOfBombs--;
        Invoke("AddBomb", fuse);
    }

    public void AddBomb()
    {
        numberOfBombs++;
    }
}
