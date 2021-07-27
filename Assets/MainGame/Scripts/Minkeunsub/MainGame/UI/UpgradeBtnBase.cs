using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class UpgradeBtnBase : MonoBehaviour
{
    [Header("cost")]
    #region cost
    public float cost;
    public float costIncrease;
    #endregion

    [Header("value")]
    #region value
    public float value;
    public float valueIncrease;
    #endregion


    [HideInInspector]
    public int level;
    [HideInInspector]
    public bool locked;

    [Header("button object")]
    public Image            characterImg;
    public TextMeshProUGUI  costTxt;
    public TextMeshProUGUI  valueTxt;
    public TextMeshProUGUI  levelTxt;
    public TextMeshProUGUI  btnName;

    [Header("sprite")]
    public Sprite           characterUnlocked;
    public Sprite           characterLocked;

    [Header("variable")]
    public string           btnNameStr;

    protected void Start()
    {
        locked = true;
        btnName.text = btnNameStr;
    }

    protected void Update()
    {
        characterImg.sprite = locked ? characterLocked : characterUnlocked;
        costTxt.text = CoinCal.Instance.GetCoinText(cost);
        valueTxt.text = CoinCal.Instance.GetCoinText(value);
        levelTxt.text = level.ToString();
        CharacterController();
    }

    public void UpgradeButton()
    {
        if (MainGameManager.Instance.curCoin - cost >= 0)
        {
            MainGameManager.Instance.curCoin -= cost;
            if (locked)
            {
                locked = false;
            }
            else
            {
                level++;
                cost *= costIncrease;
                value *= valueIncrease;
            }
            MainGameManager.Instance.UpgradeLogic();
        }
    }

    public abstract void CharacterController();
}
