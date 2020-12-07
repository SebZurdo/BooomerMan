using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollisionSkate : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Pickup2(collider);
        }
        if (collider.CompareTag("Player_2"))
        {
            Pickup2_2(collider);
        }

    }

     private void Pickup2(Collider2D player)
    {
        Player1 speed = player.GetComponent<Player1>();
        speed.movSpeed += 0.25f;
        Destroy(gameObject);
    }
    private void Pickup2_2(Collider2D player)
    {
        Player2 speed = player.GetComponent<Player2>();
        speed.movSpeed += 0.25f;
        Destroy(gameObject);
    }

}