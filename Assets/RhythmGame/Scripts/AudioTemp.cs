using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTemp : MonoBehaviour
{
    AudioSource myMusic;
    bool MusicOn = false;
    // Start is called before the first frame update
    void Start()
    {
        myMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(MusicOn == false)
        {
            if (collision.CompareTag("Note"))
            {
                myMusic.Play();
                MusicOn = true;
            }
        }

    }
}
