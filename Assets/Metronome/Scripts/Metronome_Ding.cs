using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome_Ding : MonoBehaviour
{
    AudioSource M_Ding;
    // Start is called before the first frame update
    void Start()
    {
        M_Ding = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bar")
        {
            M_Ding.Play();
        }

    }
}
