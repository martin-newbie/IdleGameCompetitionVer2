using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateManage : MonoBehaviour
{
    [SerializeField]
    Transform Target = null;

    public Text Score;

    int Scores = 1;

    //public Button bt;
    private float ButtonTimer = 1f;

    bool isButtonClick = false;

    AudioSource MyAudio;

    public float RotateSpeed = 0;
    // Start is called before the first frame update
     void Start()
    {
        MyAudio = GetComponent<AudioSource>();

     //   bt = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        BarRotate();

        Score.text = "Score : " + Scores;

        if (isButtonClick == true) 
        {
            ButtonTimer -= 1 * Time.deltaTime;

            if (ButtonTimer == 0)
            {
                isButtonClick = false;
                Debug.Log("TimerFalse");
            }
        }

    }

    public void BarRotate()
    {
        this.transform.RotateAround(Target.position, Vector3.forward, RotateSpeed * Time.deltaTime);
        
       /* if (this.transform.rotation.z <= 40)
        {
            Debug.Log("Inverse1");
            RotateSpeed = 100;
        }*/
       if(RotateSpeed ==40)
        {
            if (this.transform.localEulerAngles.z >= 40)
            {
                Debug.Log("Inverse1");
                RotateSpeed = -40;
            }
        }

       if(RotateSpeed ==-40)
        {
            if (this.transform.localEulerAngles.z >= 180)
            {
                Debug.Log("Inverse2");
                RotateSpeed = 40;
            }
        }


    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(isButtonClick == true)
        {
            if (col.tag == "Finish")
            {
                MyAudio.Play();
                Scores++;
                Debug.Log("점수");
            }
        }
     

    }

    public void Button1()
    {
        isButtonClick = true;
        Debug.Log("ButtonSet");
        
    }
}
