﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBar : MonoBehaviour
{
    Vector2 target = new Vector2(2.55f, 0);


    public Text Level;
    public bool front;
    public float speed = 2.5f;

    int level = 1;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
            Debug.Log("Hit");

        front = (front == true) ? (transform.position.x == target.x ? front = false : front = true) :
                                  (transform.position.x == -target.x ? front = true : front = false);

        if (front)
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, -target, speed * Time.deltaTime);

        Level.text = "Level : " + level;

        Hitspeed();

        if(level > 5)
        {
            Debug.Log("You Win");
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyDown("space"))
            if (col.tag == "Finish")
            {
                level++;
                Debug.Log("GreenZone");
            }
    }

    void Hitspeed()
    {
        switch(level)
        {
            case 1:
                speed = 2.5f;
                break;
            case 2: speed = 3.5f;
                break;
            case 3:
                speed = 4f;
                break;
            case 4:
                speed = 5f;
                break;
            case 5:
                speed = 6f;
                break;
            default:
                break;
        }
    }
}
