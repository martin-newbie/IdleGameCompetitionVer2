using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Numerics;

public enum MapEnum
{
    Orchestra,
    Jazz,
    Band
}

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


    public MapEnum curMap;

    UnityEngine.Vector2 mousePos;
    [Header("objects")]
    public Camera mainCamera;
    public GameObject[] coin;
    public bool isCoinIncrease = false;
    public GameObject particle;
    public SoundManager SM;

    #region circleGauge
    [Header("circle gauge")]
    public Image circleGauge;
    public float circleDelay;
    public float circleCur;
    public float circleDelayAmount;
    public BigInteger curcleAmount;
    #endregion

    #region curCoin
    [Header("current coin")]
    public TextMeshProUGUI curCoinTxt;
    public BigInteger touchCoinAmt;
    public BigInteger curCoin;
    public BigInteger increaseCoin;
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
    [Header("Locked")]
    public bool[] mapUnlocked;
    int lockMap;
    #endregion
    void Start()
    {
        map1Upgrades[0].GetComponent<UpgradeBtnBase>().locked = false;
        circleCur = circleDelay;
        MapSelect(0);
        UpgradeLogic();
        TimeCoin();
        mapUnlocked[0] = true;
        curMap = 0;
        CoinLoad();
        Save();
    }

    void Update()
    {
        CoinLogic();
        TimeCoinLogic();
        //MapLogic();

        #region coinTest
        if (Input.GetKeyDown(KeyCode.S))
            curCoin -= touchCoinAmt;
        if (Input.GetKeyDown(KeyCode.A))
            curCoin += touchCoinAmt * 10000;
        #endregion
        MapLogic();

        if (mapUnlocked[1]) map2Upgrades[0].GetComponent<UpgradeBtnBase>().locked = false;
        if (mapUnlocked[2]) map3Upgrades[0].GetComponent<UpgradeBtnBase>().locked = false;
    }

    void CoinSave()
    {
        PlayerPrefs.SetString("curcoin", curCoin.ToString());
    }

    void CoinLoad()
    {
        if (PlayerPrefs.GetString("curcoin") != "")
        {
            curCoin = BigInteger.Parse(PlayerPrefs.GetString("curcoin"));
            increaseCoin = curCoin;
        }
    }

    public void UpgradeLogic()
    {
        touchCoinAmt = 50;
        for (int i = 0; i < characterUpgrade.Length; i++)
        {
            characterUpgrade[i].gameObject.SetActive(true);
            if (!characterUpgrade[i].locked)
                touchCoinAmt += (BigInteger)characterUpgrade[i].value;
            characterUpgrade[i].gameObject.SetActive(false);
        }

    }

    void CoinLogic()
    {
        if (increaseCoin < curCoin)
        {
            BigInteger offset = curCoin - increaseCoin;
            increaseCoin += (offset * (int)(Time.deltaTime * 1000000)) / 4000000;
        }
        else if (increaseCoin > curCoin)
        {
            BigInteger offset = increaseCoin - curCoin;
            increaseCoin -= (offset * (int)(Time.deltaTime * 1000000)) / 4000000;
        }

        if (Mathf.Abs((float)(curCoin - increaseCoin)) < 0.5)
            increaseCoin = curCoin;

        BigInteger TmpIncreaseCoin = increaseCoin;

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
        Instantiate(coin[rand], mousePos, UnityEngine.Quaternion.identity);
    }

    void TimeCoin()
    {
        curcleAmount = 100;
        for (int i = 0; i < coinUpgrade.Length; i++)
        {
            if (!coinUpgrade[i].locked)
                curcleAmount += coinUpgrade[i].value;
        }
        curCoin += curcleAmount;
        isCoinIncrease = true;
        Instantiate(particle, circleGauge.transform.position, UnityEngine.Quaternion.identity);
    }

    public void MapSelect(int n)
    {
        lockMap = n;
        if (mapUnlocked[lockMap])
        {
            curMap = (MapEnum)lockMap;
            SM.BackgroundSfx();
        }
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
    }

    void MapLogic()
    {
        if (mapUnlocked[(int)curMap])
        {
            switch (curMap)
            {
                case MapEnum.Orchestra:
                    mapImg.sprite = mapImgs[0];
                    for (int j = 0; j < map1Upgrades.Length; j++)
                    {
                        map1Upgrades[j].SetActive(true);
                        map1Upgrades[j].GetComponent<ChracterUpgradeButton>().selected = true;
                    }
                    break;
                case MapEnum.Band:
                    mapImg.sprite = mapImgs[1];
                    for (int i = 0; i < map2Upgrades.Length; i++)
                    {
                        map2Upgrades[i].SetActive(true);
                        map2Upgrades[i].GetComponent<ChracterUpgradeButton>().selected = true;
                    }
                    break;
                case MapEnum.Jazz:
                    mapImg.sprite = mapImgs[2];
                    for (int i = 0; i < map3Upgrades.Length; i++)
                    {
                        map3Upgrades[i].SetActive(true);
                        map3Upgrades[i].GetComponent<ChracterUpgradeButton>().selected = true;
                    }
                    break;
            }
        }

    }

    private void OnDestroy()
    {
        CoinSave();
        PlayerPrefs.SetString("SaveLastTime", System.DateTime.Now.ToString());
        Debug.Log(System.DateTime.Now.ToString());
    }

    void Save()
    {
        string lastTime = PlayerPrefs.GetString("SaveLastTime");
        System.DateTime lastDateTime = System.DateTime.Parse(lastTime);
        System.TimeSpan compareTime = System.DateTime.Now - lastDateTime;

        var idleTime = compareTime.TotalSeconds / circleDelay;
        curCoin += (int)(idleTime * 10) * curcleAmount / 10;
        increaseCoin = curCoin;
        Debug.Log((int)(idleTime * 10) * curcleAmount / 10);
    }

    public void MapBuy(int cost)
    {
        if (cost <= curCoin && !mapUnlocked[lockMap])
        {
            curCoin -= cost;
            mapUnlocked[lockMap] = true;
        }
    }

    public void MinigameMove(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
