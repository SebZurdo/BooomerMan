using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject FirePower;
    public Player1 Player;
    public Player2 Player_2;
    public GameObject SkatePower;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player1>();
            Player.Dies();
        }

        else if (collider.CompareTag("Player_2"))
        {
            Player_2 = GameObject.FindGameObjectWithTag("Player_2").GetComponent<Player2>();
            Player_2.Dies();
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
