using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject FirePower;

    public GameObject SkatePower;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Dead dog");
        }
        else if(collider.CompareTag("PowerUp"))
        {
            Debug.Log("Dead object");
        }
        
    }

    private void DestroyItself()
    {
        Destroy(gameObject);
    }

    private void DestroyOther(GameObject Powerup)
    {
        if(Powerup == FirePower)
        {
            Destroy(Powerup);
        }
        if (Powerup == SkatePower)
        {
            Destroy(Powerup);
        }
    }
}
