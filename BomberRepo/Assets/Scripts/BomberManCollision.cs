﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberManCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Explosion"))
        {
            Debug.Log("Dead");
        }
       
    }
}
