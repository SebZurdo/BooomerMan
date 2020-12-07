using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollisionFire : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Player"))
        {
            Pickup(collider);
        }
        

    }

    void Pickup(Collider2D player)
    {
        Player1 power = player.GetComponent<Player1>();
        power.BombPower += 1;
        Destroy(gameObject);
    }


}
