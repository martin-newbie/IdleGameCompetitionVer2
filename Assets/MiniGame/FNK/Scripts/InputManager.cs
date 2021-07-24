using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;

    float time = 0;
    float size = 3;
    float UpSizeTime = 0.2f;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            time = 0;
        }
        if (time <= UpSizeTime)
        {
            sprite.transform.localScale = (Vector3.one / 3) * (1 + size * time);
        }
        else if (time <= UpSizeTime * 2)
        {
            sprite.transform.localScale = (Vector3.one / 3) * (2 * size * UpSizeTime + 1 - time * size);
        }
        else
        {
            sprite.transform.localScale = (Vector3.one / 3);
        }
        time += Time.deltaTime;
    }
}
