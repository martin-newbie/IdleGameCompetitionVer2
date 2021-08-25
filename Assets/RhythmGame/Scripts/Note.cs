using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float speed;
    public int Notetype;

    void Update()
    {
        transform.position -= Vector3.up * speed * Time.deltaTime;
    }
}
