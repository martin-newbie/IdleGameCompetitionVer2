using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    SelectMusic selectMusic;

    AudioSource Music;
    [SerializeField] AudioClip[] audios;

    bool musicStart = false;

    private void Start()
    {
        selectMusic = FindObjectOfType<SelectMusic>();
        Music = GetComponent<AudioSource>();

        switch (selectMusic.Music)
        {
            case 0: // GoRock
                Music.clip = audios[0];
                break;
            case 1: // TheHunter
                Music.clip = audios[1];
                break;
            case 2: //Cantina
                Music.clip = audios[2];
                break;
        }
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
