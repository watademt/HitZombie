using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelHealth : MonoBehaviour
{
    public int levelHealth = 100;
    float timer=0;

    void Update()
    {
        if (levelHealth < 5)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
