using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class CoinCal : MonoBehaviour
{

    private static CoinCal instance = null;
    public static CoinCal Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType(typeof(CoinCal)) as CoinCal;
                if (instance == null) Debug.LogError("no coin calculation");
            }
            return instance;
        }
    }

    public string GetCoinText(float amount)
    {
        int placeN = 3;
        BigInteger value = (BigInteger)amount;
        List<int> numList = new List<int>();
        int p = (int)Mathf.Pow(10, placeN);

        do
        {
            numList.Add((int)(value % p));
            value /= p;
        } while (value >= 1);
        int num = numList.Count < 2 ? numList[0] : numList[numList.Count - 1] * p + numList[numList.Count - 2];
        float f = (num / (float)p);
        return f.ToString("N2") + "  " + GetUnitText(numList.Count - 1);
    }

    private string GetUnitText(int index)
    {
        int idx = index - 1;
        if (idx < 0) return "A";
        int repeatCount = (idx / 26) + 1;
        string retStr = "";
        for (int i = 0; i < repeatCount; i++)
        {
            retStr += (char)(65 + idx % 26);
        }
        return retStr;
    }

}
