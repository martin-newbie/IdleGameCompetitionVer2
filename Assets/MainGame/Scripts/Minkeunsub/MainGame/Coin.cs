using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    public GameObject particle;
    SpriteRenderer SR;
    Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        #region Random color
        /*float r, g, b;
        r = Random.Range(0, 255);
        g = Random.Range(0, 255);
        b = Random.Range(0, 255);
        r = r / 255;
        g = g / 255;
        b = b / 255;
        var color = SR.color;
        color.r = r;
        color.g = g;
        color.b = b;
        SR.color = color;*/
        #endregion 
        scale = new Vector3(0.7f, 0.7f, 1);
        Invoke("Destroy", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.DOScale(scale, 0.5f);
    }

    void Destroy()
    {
        MainGameManager.Instance.curCoin += MainGameManager.Instance.touchCoinAmt;
        MainGameManager.Instance.isCoinIncrease = true;
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
