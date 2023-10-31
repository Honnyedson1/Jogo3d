using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip audio;

    private void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Source.clip = audio;
            Source.Play();
            Destroy(gameObject);
        }
    }
}
