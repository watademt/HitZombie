using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Enemy"))
        {
            other.GetComponent<EnemyScript>().HP -= 50;
        }
    }
}
