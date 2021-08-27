using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateManage : MonoBehaviour
{
    public float BTimer = 0;

    [SerializeField]
    Transform Target = null;

    public int Level = 1;

    public float CurrentRotate;

    public bool RotationInverse = false;

    AudioSource MyAudio;

    public GameObject End;

    public float Mat_Score = 0;

    public Text Timer;

    bool State = false;
    bool isWin = false;

    float Score = 0;

    bool SpawnOnce = true;



    public float RotateSpeed = 0;
    // Start is called before the first frame update
     void Start()
    {
        BTimer = 10;
        State = false;
        MyAudio = GetComponent<AudioSource>();
        Score = Random.Range(100, 200);
     //   bt = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentRotate = this.transform.localEulerAngles.z;

        BarRotate();

        switch(Level)
        {
            case 7: RotateSpeed = 0;State = true; isWin = true;
                break;
        }

        Mat_Timer();
        GameEnd();
    }

    public void BarRotate()
    {
        this.transform.RotateAround(Target.position, Vector3.forward, RotateSpeed * Time.deltaTime);
       

       if(RotationInverse==false)
        {
            if (CurrentRotate >= 40)
            {
                RotateSpeed = -60;
                RotationInverse = true;
            }
        }

        if(RotationInverse==true)
        {
            if (CurrentRotate >= 320)
            {
                RotateSpeed = 60;
                RotationInverse = false;
            }
        }

    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (col.tag == "Finish")
            {
                MyAudio.Play();
                Level++;
            }
        }

    }

    public void Mat_Timer()
    {
        if(State==false)
        {
            if (BTimer > 0)
                BTimer -= Time.deltaTime;
            Timer.text = Mathf.Ceil(BTimer).ToString();
        }


        if (BTimer < 0)
        {
            Timer.text = "Lose";
            State = true;
            Mat_Score = Score;
            RotateSpeed = 0;
        }

        if (isWin == true)
        {
            if (SpawnOnce == true)
            {
                Timer.text = "Win";
                Mat_Score = Score * BTimer;
            }
        }
    }

    public void GameEnd()
    {
        if (SpawnOnce == true)
        {
            if (isWin == true || BTimer < 0)
            {
                End.gameObject.SetActive(true);
                SpawnOnce = false;
            }
        }

        if (State == false)
        {
            End.gameObject.SetActive(false);
        }
    }
}
