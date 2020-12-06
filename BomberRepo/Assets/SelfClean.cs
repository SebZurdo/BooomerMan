using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfClean : MonoBehaviour
{
    public float SelfDestroy = 0.2f;

    // Update is called once per frame
    void Update()
    {
        SelfDestroy -= Time.deltaTime;

        if (SelfDestroy <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
