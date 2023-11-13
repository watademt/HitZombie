using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            animator.Play("Base Layer.AxeAtack");
        }
    }
}