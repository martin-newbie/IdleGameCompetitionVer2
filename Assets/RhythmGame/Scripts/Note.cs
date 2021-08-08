using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float NoteSpeed = 7000;
    void Update()
    {
       // GameObject.FindWithTag("Note");
        transform.localPosition += Vector3.down * NoteSpeed * Time.deltaTime;
    }
}
