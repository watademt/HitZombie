using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(DestroyMessage());
    }
    IEnumerator DestroyMessage()
    {
        yield return new WaitForSeconds(6.0f);
        Destroy(gameObject);
    }
}
