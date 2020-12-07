using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterDeath_2 : MonoBehaviour
{
    void NextScreen()
    {
        SceneManager.LoadScene(4);
    }
}
