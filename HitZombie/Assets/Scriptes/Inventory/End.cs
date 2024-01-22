using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    void Start()
    {
        Invoke("Menu", 5.0f);
    }
    void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
