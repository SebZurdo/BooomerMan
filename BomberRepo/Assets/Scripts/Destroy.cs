using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject FirePower;
    public Player1 Player;
    public GameObject SkatePower;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player1>();
            Player.Dies();
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

    
}
