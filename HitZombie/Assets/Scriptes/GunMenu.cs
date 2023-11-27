using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMenu : MonoBehaviour
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Weapon1.SetActive(true);
            Weapon2.SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {
            Weapon1.SetActive(false);
            Weapon2.SetActive(true);
        }
    }
}
