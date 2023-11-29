using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator animator;
    public Rigidbody[] allRigidbodies;
    public int HP = 100;

    private void Awake()
    {
        for (int i = 0; i < allRigidbodies.Length; i++)
        {
            allRigidbodies[i].isKinematic = true;
        }
    }
    public void Death()
    {
        animator.enabled = false;
        for (int i = 0; i < allRigidbodies.Length; i++)
        {
            allRigidbodies[i].isKinematic=false;
        }
    }
}
