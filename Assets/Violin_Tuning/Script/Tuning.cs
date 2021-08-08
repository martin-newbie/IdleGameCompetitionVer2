using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuning : MonoBehaviour
{
    private float Rot;

    Vector2 MousePos, TargetPos, TransPos;

    bool isSelect = false;
    bool isSelect2 = false;

    bool isDone = false;

    // Start is called before the first frame update
    void Start()
    {
        TargetPos = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (isDone == false)
        {
            if (isSelect == true || isSelect2 == true)
            {
                if (Input.GetMouseButton(0))
                {
                    TuningRot();
                }

            }
        }


    }

    public void TuningRot()
    {
        MousePos = Input.mousePosition;
        TransPos = Camera.main.ScreenToWorldPoint(MousePos);
        Rot = Mathf.Atan2(TransPos.y - TargetPos.y, TransPos.x - TargetPos.x) * Mathf.Rad2Deg;

        this.transform.rotation = Quaternion.AngleAxis(Rot - 90, Vector3.forward);
    }

    public void WinRequire()
    {
        if (this.transform.rotation.eulerAngles.z == 50)
        {
            isDone = true;
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
}
