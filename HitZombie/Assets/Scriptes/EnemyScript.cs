using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator animator;
    public Rigidbody[] allRigidbodies;
    private int HP = 100;

    private void Awake()
    {
        for (int i = 0; i < allRigidbodies.Length; i++)
        {
            allRigidbodies[i].isKinematic = true;
        }
    }
    void Update()
    {
        if (HP <= 0) Death();
    }
    public void Death()
    {
        GetComponent<Collider>().enabled = false;
        animator.enabled = false;
        for (int i = 0; i < allRigidbodies.Length; i++)
        {
            allRigidbodies[i].isKinematic=false;
        }
    }
    public void TakeDamage(int damageAmount)
    {
        HP-=damageAmount;
    }
}
