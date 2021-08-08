using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] Image[] image;

    float time = 0;
    float size = 0.8f;
    float UpSizeTime = 0.2f;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            time = 0;
        }
        for(int i = 0; i < image.Length; i++)
        {
            if (time <= UpSizeTime)
            {
                image[i].transform.localScale = (Vector3.one) * (1 + size * time);
            }
            else if (time <= UpSizeTime * 2)
            {
                image[i].transform.localScale = (Vector3.one) * (2 * size * UpSizeTime + 1 - time * size);
            }
            else
            {
                image[i].transform.localScale = (Vector3.one);
            }
        }
        time += Time.deltaTime;
    }
}
