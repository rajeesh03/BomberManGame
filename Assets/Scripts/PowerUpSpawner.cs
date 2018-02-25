using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour{

    public GameObject[] powerUps;
    PowerUpController powerUpController;

    public void SpawnPowerUp()
    {
        powerUpController = FindObjectOfType<PowerUpController>();

        int randomIndex = Random.Range(0, powerUps.Length);
		if(Random.Range(0f,2.0f) >1.3f)
        {
            powerUpController.CmdSpawnPowerUp(transform.position, powerUps[randomIndex]);
        }
    }

}
