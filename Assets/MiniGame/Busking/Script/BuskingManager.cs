using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuskingManager : MonoBehaviour
{
    [SerializeField] Slider timerbar;
    [SerializeField] GameObject Clear;

    float cur_time = 30;
    float max_time = 100;

    public float CountSpeed = 5;
    public float FillBar = 1;

    void Start()
    {
        timerbar.value = (float)cur_time / (float)max_time;
        Clear.SetActive(false);
    }

    void Update()
    {
        if(cur_time >= max_time)
        {
            Clear.SetActive(true);
        }
        else
        {
            cur_time -= Time.deltaTime * CountSpeed;
            timerbar.value = (float)cur_time / (float)max_time;

            if (Input.anyKeyDown)
            {
                if (cur_time < max_time)
                    cur_time += FillBar;
            }
        }
    }

    void OnMouseDown()
    {
        if (cur_time <= max_time)
        {
            if (cur_time < max_time)
                cur_time += FillBar;
            Debug.Log("OnClick");
        }
    }
}
