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

    }

     private void Pickup2(Collider2D player)
    {
        Player_1 speed = player.GetComponent<Player_1>();
        speed.movSpeed += 0.25f;
        Destroy(gameObject);
    }

    private void DestroyItself()
    {
        Destroy(gameObject);
    }

}