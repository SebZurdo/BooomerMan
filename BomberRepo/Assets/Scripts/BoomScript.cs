﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour
{
    public float TwoSeconds = 2f;

    // Update is called once per frame
    void Update()
    {
        TwoSeconds -= Time.deltaTime;

        if(TwoSeconds <= 0f)
        {
            FindObjectOfType<TileDestroyer>().Explode(transform.position);
            Destroy(gameObject);
        }
    }
}
