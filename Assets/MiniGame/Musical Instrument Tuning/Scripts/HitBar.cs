using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBar : MonoBehaviour
{
    Vector2 target = new Vector2(2.55f, 0);
    Vector2 pos;
    Vector2 safe_pos;

    public GameObject safe_zone;
    public Text Level;
    public GameObject clear;
    public bool front;
    public float speed = 2.5f;

    int level = 1;

    void Start()
    {
    }

    void Update()
    {
        pos = transform.position;
        safe_pos = safe_zone.transform.position;

        front = (front == true) ? (transform.position.x == target.x ? front = false : front = true) :
                                  (transform.position.x == -target.x ? front = true : front = false);

        if (front)
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, -target, speed * Time.deltaTime);

        if (level >= 4)
        {
            Level.text = "Clear";
            clear.SetActive(true);
            speed = 0;
        }
        else
            Level.text = "Level : " + level;
    }

    void Hit()
    {
        level++;
        speed += 2;
        pos.x = -2.55f;
        safe_pos.x = Random.Range(-2f,2f);
        safe_zone.transform.position = safe_pos;
        transform.position = pos;
        Debug.Log("GreenZone");
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyDown("space"))
        {
            if (col.tag == "Finish")
                Hit();
            Debug.Log(col.tag);
        }
    }
}
