using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelHealth : MonoBehaviour
{
    public int levelHealth = 100;
    public Slider mySlider;
    public Image myImage;
    float timer=0;

    void Update()
    {
        mySlider.value = levelHealth;
        if (levelHealth < 10)
        {
            timer += Time.deltaTime;
            myImage.enabled = false;
            if (timer > 1)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        else
        {
            myImage.enabled = true;
        }
    }
}
