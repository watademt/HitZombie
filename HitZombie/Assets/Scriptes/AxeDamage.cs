using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDamage : MonoBehaviour
{
    public int damageAmount = 50;
    public AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            other.GetComponent<EnemyScript>().TakeDamage(damageAmount);
        }
    }
}
