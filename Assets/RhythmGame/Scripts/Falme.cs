using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falme : MonoBehaviour
{
    public AudioSource Music;

    bool musicStart = false;
    private void Start()
    {
        Music = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!musicStart)
        {
            if (col.CompareTag("Note"))
            {
                Music.Play();
                musicStart = true;
            }
        }
    }
}
