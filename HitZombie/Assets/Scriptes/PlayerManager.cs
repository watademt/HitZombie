using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static int playerHealth;
    public static bool isGameOver;
    public TextMeshProUGUI playerHPText;

    void Start()
    {
        isGameOver = false;
        playerHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        playerHPText.text = "" + playerHealth;
        if (isGameOver)
        {
            SceneManager.LoadScene("TestPolygon2");
        }
    }


    public static void Damage(int damageCount)
    {
        playerHealth -= damageCount;
        if (playerHealth<=0)
            isGameOver = true;
    }
}