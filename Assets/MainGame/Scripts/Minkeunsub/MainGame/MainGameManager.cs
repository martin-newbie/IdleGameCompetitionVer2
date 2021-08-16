﻿using System.Collections;
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
    public Camera mainCamera;
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

    #region map
    [Header("Maps")]
    public SpriteRenderer mapImg;
    public Sprite[] mapImgs;
    [Header("Upgrades")]
    public GameObject[] map1Upgrades;
    public GameObject[] map2Upgrades;
    public GameObject[] map3Upgrades;
    [Header("Characters")]
    public GameObject[] map1Characters;
    public GameObject[] map2Characters;
    public GameObject[] map3Characters;

    int curMap;
    #endregion
    void Start()
    {
        Save();
        map1Upgrades[0].GetComponent<UpgradeBtnBase>().locked = false;
        map2Upgrades[0].GetComponent<UpgradeBtnBase>().locked = false;
        circleCur = circleDelay;
        MapSelect(0);
    }

    void Update()
    {
        CoinLogic();
        TimeCoinLogic();
        //MapLogic();

        #region coinTest
        if (Input.GetKeyDown(KeyCode.S))
            curCoin -= touchCoinAmt;
        #endregion
        MapLogic();

    }

    public void UpgradeLogic()
    {
        touchCoinAmt = 300;
        for (int i = 0; i < characterUpgrade.Length; i++)
        {
            if(!characterUpgrade[i].locked)
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
        mousePos = mainCamera.ScreenToWorldPoint(mousePos);
        int rand = Random.Range(0, coin.Length);
        Instantiate(coin[rand], mousePos, Quaternion.identity);
    }

    void TimeCoin()
    {
        curcleAmount = 1000;
        for (int i = 0; i < coinUpgrade.Length; i++)
        {
            if(!coinUpgrade[i].locked)
                curcleAmount += coinUpgrade[i].value;
        }
        curCoin += curcleAmount;
        isCoinIncrease = true;
        Instantiate(particle, circleGauge.transform.position, Quaternion.identity);
    }

    public void MapSelect(int n)
    {
        for (int j = 0; j < map1Upgrades.Length; j++)
        {
            map1Upgrades[j].SetActive(false);
            map1Characters[j].SetActive(false);
            map1Upgrades[j].GetComponent<ChracterUpgradeButton>().selected = false;
        }
        for (int i = 0; i < map2Upgrades.Length; i++)
        {
            map2Upgrades[i].SetActive(false);
            map2Characters[i].SetActive(false);
            map2Upgrades[i].GetComponent<ChracterUpgradeButton>().selected = false;
        }
        for (int i = 0; i < map3Upgrades.Length; i++)
        {
            map3Upgrades[i].SetActive(false);
            map3Characters[i].SetActive(false);
            map3Upgrades[i].GetComponent<ChracterUpgradeButton>().selected = false;
        }
        curMap = n;
    }

    void MapLogic()
    {
        switch(curMap)
        {
            case 0:
                mapImg.sprite = mapImgs[0];
                for (int j = 0; j < map1Upgrades.Length; j++)
                {
                    map1Upgrades[j].SetActive(true);
                    map1Upgrades[j].GetComponent<ChracterUpgradeButton>().selected = true;
                }
                break;
            case 1:
                mapImg.sprite = mapImgs[1];
                for (int i = 0; i < map2Upgrades.Length; i++)
                {
                    map2Upgrades[i].SetActive(true);
                    map2Upgrades[i].GetComponent<ChracterUpgradeButton>().selected = true;
                }
                break;
            case 2:
                mapImg.sprite = mapImgs[2];
                for (int i = 0; i < map3Upgrades.Length; i++)
                {
                    map3Upgrades[i].SetActive(true);
                    map3Upgrades[i].GetComponent<ChracterUpgradeButton>().selected = true;
                }
                break;
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetString("SaveLastTime", System.DateTime.Now.ToString());
        Debug.Log(System.DateTime.Now.ToString());
    }

    void Save()
    {
        string lastTime = PlayerPrefs.GetString("SaveLastTime");
        System.DateTime lastDateTime = System.DateTime.Parse(lastTime);
        System.TimeSpan compareTime = System.DateTime.Now - lastDateTime;

        Debug.Log(System.DateTime.Now.ToString());
        Debug.LogFormat("{0}", compareTime.TotalSeconds);
    }
}
