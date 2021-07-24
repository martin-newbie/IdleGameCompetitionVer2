using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    AudioSource audio;
    bool musicStart = false;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!musicStart)
        {
            if (col.CompareTag("Note"))
            {
                audio.Play();
                musicStart = true;
            }
        }
    }
}
