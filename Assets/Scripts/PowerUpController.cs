using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {

    public void SpawnPowerUp(Vector3 position, GameObject powerUp)
    {
		GameObject newPowerUp = Instantiate(powerUp, position,
            Quaternion.identity) as GameObject;
    }

}
