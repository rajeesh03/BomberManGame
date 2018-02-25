using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {

    public void CmdSpawnPowerUp(Vector3 position, GameObject powerUp)
    {
        var newPowerUp = Instantiate(powerUp, position,
            Quaternion.identity) as GameObject;
    }

}
