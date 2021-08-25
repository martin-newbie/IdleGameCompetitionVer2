using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuning : MonoBehaviour
{
    private float Rot;

    Vector2 MousePos, TargetPos, TransPos;


    bool isSelect = false;
    bool isSelect2 = false;

    public Text TimerText;
    private float Timer;

    public GameObject Button1;
    public GameObject Button2;

    public Transform Obj1;
    public Transform Obj2;

    public bool isDone1 = false;
    public bool isDone2 = false;

    public float Win1;
    public float Win2;

    public float CurRot1 = 0;
    public float CurRot2;

    public float WinRange1;
    public float WinRange2;

    public bool GameWin = false;


    private void Awake()
    {
        TargetPos = transform.position;
        Win1 = Random.Range(0, 360);
        Win2 = Random.Range(0, 360);
        Obj1.eulerAngles = new Vector3(0, 0, Win1);
        Obj2.eulerAngles = new Vector3(0, 0, Win2);
        Timer = 10f;
    }


    // Update is called once per frame
    void Update()
    {
        CurRot1 = Button1.transform.eulerAngles.z;
        CurRot2 = Button2.transform.eulerAngles.z;

        WinRange1 = Obj1.eulerAngles.z;
        WinRange2 = Obj2.eulerAngles.z;

        GetRotation();

        TimerCount();

        WinRequire();

        if (isDone1 == false)
        {
            if (isSelect == true)
            {
                if (Input.GetMouseButton(0))
                {
                    TuningRot();
                    //Debug.Log("1번 회전중");
                }

            }
        }

        if(isDone2==false)
        {
            if(isSelect2==true)
            {
                if(Input.GetMouseButton(0))
                {
                    TuningRot2();
                   // Debug.Log("2번 회전중");
                }
            }
        }

        if(isDone1==true&&isDone2==true)
        {
            GameWin = true;
        }

    }
    public void GetRotation()
    {
        MousePos = Input.mousePosition;
        TransPos = Camera.main.ScreenToWorldPoint(MousePos);
        Rot = Mathf.Atan2(TransPos.y - TargetPos.y, TransPos.x - TargetPos.x) * Mathf.Rad2Deg;
        Debug.Log("각도 구함");
    }

    public void TuningRot()
    {
        Button1.transform.rotation = Quaternion.AngleAxis(Rot - 90, Vector3.forward);
    }

    public void TuningRot2()
    {
        Button2.transform.rotation = Quaternion.AngleAxis(Rot - 90, Vector3.forward);
    }



    public void WinRequire()
    {
        if (CurRot1 >= WinRange1 - 5 && CurRot1 <= WinRange1 + 5) 
        //if(CurRot1 == 50)
        {
            isDone1 = true;
            
            //isSelect = false;
        }

        if (CurRot2 >= WinRange2 - 5 && CurRot2 <= WinRange2 + 5)
        //if(CurRot1 == 50)
        {

            isDone2 = true;
            //isSelect = false;
        }
    }

    public void SelectTun1()
    {
        isSelect = true;
        isSelect2 = false;
    }

    public void SelectTun2()
    {
        isSelect = false;
        isSelect2 = true;

    }

    public void TimerCount()
    {
        if(GameWin==false)
        {
            if (Timer > 0)
                Timer -= Time.deltaTime;
            TimerText.text = Mathf.Ceil(Timer).ToString();
        }

        if(Timer == 0)
        {
            TimerText.text = "Lose";
            Time.timeScale = 0;
        }

        if(GameWin==true)
        {
            TimerText.text = "Win";
            
        }
    }

}
