using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecord : MonoBehaviour
{
    RotateManage Mat_Manager;

    public float ScoreRedcorded = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Mat_Manager = FindObjectOfType<RotateManage>();
    }
    void Update()
    {

    }

    public void RecordCal()
    {

        ScoreRedcorded = Mat_Manager.Mat_Score;
    }
}
