using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainGameManager : MonoBehaviour
{

    private static MainGameManager instance;
    public static MainGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(MainGameManager)) as MainGameManager;
                if (instance == null)
                    Debug.LogError("no main game manager available");
            }

            return instance;
        }
    }

    Vector2 mousePos;
    public Camera cameras;
    public GameObject coin;

    public bool isCoinIncrease = false;

    #region circleGauge
    public Image circleGauge;
    public float circleDelay;
    public float circleCur;
    public float circleDelayAmount;
    #endregion

    #region curCoin
    public TextMeshProUGUI curCoinTxt;
    public float touchCoinAmt;
    public float curCoin;
    public float increaseCoin;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        circleCur = circleDelay;
    }

    // Update is called once per frame
    void Update()
    {
        CoinLogic();
        TimeCoinLogic();

        #region coinTest
        if (Input.GetKeyDown(KeyCode.S))
            curCoin -= touchCoinAmt;
        #endregion

    }

    void CoinLogic()
    {
        float duration = 0.5f;
        if (increaseCoin < curCoin)
        {
            float offset = (curCoin - increaseCoin) / duration;
            increaseCoin += offset * Time.deltaTime;

        }
        else if (increaseCoin > curCoin)
        {
            float offset = (increaseCoin - curCoin) / duration;
            increaseCoin -= offset * Time.deltaTime;
        }

        if (Mathf.Abs(curCoin - increaseCoin) < 0.5)
            increaseCoin = curCoin;

        int TmpIncreaseCoin = (int)increaseCoin;
        curCoinTxt.text = CoinCal.Instance.GetCoinText(TmpIncreaseCoin);
    }

    void TimeCoinLogic()
    {
        circleGauge.fillAmount = circleCur / circleDelay;
        if (circleCur > 0)
            circleCur -= Time.deltaTime * circleDelayAmount;
        else circleCur = circleDelay;
    }

    public void ScreenOnClick()
    {
        mousePos = Input.mousePosition;
        mousePos = cameras.ScreenToWorldPoint(mousePos);
        Instantiate(coin, mousePos, Quaternion.identity);
    }

}
