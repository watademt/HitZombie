using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Damage : MonoBehaviour
{
    public AudioSource mySource;
    public int x;
    void Start()
    {
        mySource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider myCollider)
    {
        x = Random.Range(5, 25);
        if (myCollider.tag == ("Player"))
        {
            myCollider.GetComponent<LevelHealth>().levelHealth -= x;
            mySource.Play();
        }
    }
}