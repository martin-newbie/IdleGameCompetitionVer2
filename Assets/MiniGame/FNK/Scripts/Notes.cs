using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public float speed;
    public int Notetype;

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}