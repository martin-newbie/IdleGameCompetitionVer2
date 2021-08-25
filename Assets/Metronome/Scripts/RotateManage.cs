using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateManage : MonoBehaviour
{
    public float BTimer = 0;

    [SerializeField]
    Transform Target = null;

    int Scores = 1;

    public float CurrentRotate;

    public bool RotationInverse = false;

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
        CurrentRotate = this.transform.localEulerAngles.z;

        BarRotate();


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
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(BTimer > 0)
        {
            if (col.tag == "Finish")
            {
                MyAudio.Play();
                Scores++;
            }
        }

    }

    public void MatButton()
    {
        if (BTimer > 0)
            BTimer -= Time.deltaTime;
       
    }

    public void PressButton()
    {
        BTimer = 1;
    }
}
