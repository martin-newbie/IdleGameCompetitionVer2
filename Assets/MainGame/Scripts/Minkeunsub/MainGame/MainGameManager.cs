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
    [Header("objects")]
    public Camera camera;
    public GameObject[] coin;
    public bool isCoinIncrease = false;
    public GameObject particle;

    #region circleGauge
    [Header("circle gauge")]
    public Image circleGauge;
    public float circleDelay;
    public float circleCur;
    public float circleDelayAmount;
    public float curcleAmount;
    #endregion

    #region curCoin
    [Header("current coin")]
    public TextMeshProUGUI curCoinTxt;
    public float touchCoinAmt;
    public float curCoin;
    public float increaseCoin;
    #endregion

    [Header("upgrade buttons")]
    public UpgradeBtnBase[] characterUpgrade;
    public UpgradeBtnBase[] coinUpgrade;

    [Header("Instagram")]
    public ProfileController profile;

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

    public void UpgradeLogic()
    {
        touchCoinAmt = 300;
        for (int i = 0; i < characterUpgrade.Length; i++)
        {
            touchCoinAmt += characterUpgrade[i].value;
        }
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
        else
        {
            TimeCoin();
            circleCur = circleDelay;
        }

    }

    public void ScreenOnClick()
    {
        mousePos = Input.mousePosition;
        mousePos = camera.ScreenToWorldPoint(mousePos);
        int rand = Random.Range(0, coin.Length);
        Instantiate(coin[rand], mousePos, Quaternion.identity);
    }


    void TimeCoin()
    {
        curcleAmount = 10;
        for (int i = 0; i < coinUpgrade.Length; i++)
        {
            curcleAmount += coinUpgrade[i].value;
        }
        curCoin += curcleAmount;
        isCoinIncrease = true;
        Instantiate(particle, circleGauge.transform.position, Quaternion.identity);
    }

}
