using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Damage : MonoBehaviour
{
    public AudioClip myClip;
    private AudioSource mySource;
    void Start()
    {
        mySource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider myCollider)
    {
        if (myCollider.tag == ("Player"))
        {
            myCollider.GetComponent<LevelHealth>().levelHealth -= 10;
            mySource.PlayOneShot(myClip);
        }
    }
}