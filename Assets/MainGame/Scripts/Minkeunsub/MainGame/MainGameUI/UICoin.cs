using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UICoin : MonoBehaviour
{
    Vector3 defaultScale;
    Vector3 increaseScale;
    public float incrAmt;
    // Start is called before the first frame update
    void Start()
    {
        defaultScale = transform.localScale;
        increaseScale = new Vector3(incrAmt, incrAmt, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(MainGameManager.Instance.isCoinIncrease)
        {
            transform.DOScale(increaseScale, 0.5f);
            if(transform.localScale.x >= incrAmt - 0.01)
                MainGameManager.Instance.isCoinIncrease = false;
        }
        else
        {
            transform.DOScale(defaultScale, 0.5f);
        }
    }
}
