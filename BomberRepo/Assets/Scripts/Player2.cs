using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Player2 : MonoBehaviour
{
   public int Alive;
    public int BombPower;
    public float movSpeed;
    public Vector3 temPos;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject PlayerCharacter;
    public GameObject DieAnimation;

    Vector2 movement;

    void Start()
    {
        BombPower = 2;
        Alive = 1;

    }

    // Update is called once per frame
    void Update()
    {
        // Reads Horizontal axis 
        if(Input.GetKey("d"))
        {
            movement.x = 1;
        }
        else if(Input.GetKey("a"))
        {
            movement.x = -1;
        }
        else
        {
            movement.x = 0;
        }

        // Reads Vertical axis
        if(Input.GetKey("w"))
        {
            movement.y = 1;
        }
        else if(Input.GetKey("s"))
        {
            movement.y = -1;
        }
        else
        {
            movement.y = 0;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movSpeed * Time.fixedDeltaTime);
    }

    public void Dies()
    {
        Renderer rend = PlayerCharacter.GetComponent<Renderer>();
        Instantiate(DieAnimation, PlayerCharacter.transform.position, Quaternion.identity);
        rend.enabled = false;
        Player2 function = PlayerCharacter.GetComponent<Player2>();
        function.enabled = false;
        transform.position = new Vector3Int(20, 20, 20);
        Alive = 0;
    }
    
}
