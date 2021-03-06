using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Numerics;

public abstract class UpgradeBtnBase : MonoBehaviour
{

    [Header("Sound effect")]
    public AudioClip unlock;
    public AudioClip upgrade;

    [Header("cost")]
    #region cost
    public float costIncrease;
    public int I_cost;
    public BigInteger cost;
    #endregion

    [Header("value")]
    #region value
    public float valueIncrease;
    public int I_value;
    public BigInteger value;
    #endregion


    [HideInInspector]
    public int level;
    [HideInInspector]
    public bool locked;

    [Header("button object")]
    public Image characterImg;
    public TextMeshProUGUI costTxt;
    public TextMeshProUGUI valueTxt;
    public TextMeshProUGUI levelTxt;
    public TextMeshProUGUI btnName;

    [Header("sprite")]
    public Sprite characterUnlocked;
    public Sprite characterLocked;

    [Header("variable")]
    public string btnNameStr;
    string saveName;

    protected void Awake()
    {
        locked = true;
        saveName = btnNameStr + btnName + characterImg.name;
        Load();
    }

    protected void Start()
    {
        btnName.text = btnNameStr;
    }

    protected void Update()
    {
        characterImg.sprite = locked ? characterLocked : characterUnlocked;
        costTxt.text = CoinCal.Instance.GetCoinText(cost);
        valueTxt.text = CoinCal.Instance.GetCoinText(value);
        levelTxt.text = level.ToString();
        CharacterController();
        Save();
        if (Input.GetKeyDown(KeyCode.R)) Refresh();
    }

    void Refresh()
    {
        level = 0;
        locked = true;
        if (I_cost == 1500) locked = false;
        cost = I_cost;
        value = I_value;
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetInt(saveName + "level", level);
        PlayerPrefs.SetString(saveName + "value", value.ToString());
        PlayerPrefs.SetString(saveName + "cost", cost.ToString());
        PlayerPrefs.SetInt(saveName + "locked", locked ? 0 : 1);
    }

    void Load()
    {
        string tCost;
        string tValue;
        int tLevel;
        tLevel = PlayerPrefs.GetInt(saveName + "level");
        tValue = PlayerPrefs.GetString(saveName + "value");
        tCost = PlayerPrefs.GetString(saveName + "cost");
        locked = PlayerPrefs.GetInt(saveName + "locked") == 0;
        if (tLevel != 0) level = tLevel;
        if (tValue != "")
        {
            value = new BigInteger(System.Convert.ToInt64(tValue));
        }
        else value = I_value;
        if (tCost != "") cost = new BigInteger(System.Convert.ToInt64(tCost));
        else cost = I_cost;
    }

    public void UpgradeButton()
    {
        if (MainGameManager.Instance.curCoin - cost >= 0)
        {
            MainGameManager.Instance.curCoin -= cost;
            if (locked)
            {
                locked = false;
                MainGameManager.Instance.SM.SfxPlay("unlock", unlock);
            }
            else
            {
                level++;
                cost = (cost * (int)(costIncrease * 10)) / 10;
                value = (value * (int)(valueIncrease * 10)) / 10;
                MainGameManager.Instance.SM.SfxPlay("upgrade", upgrade);
            }
            MainGameManager.Instance.UpgradeLogic();
        }
    }

    public abstract void CharacterController();
}
