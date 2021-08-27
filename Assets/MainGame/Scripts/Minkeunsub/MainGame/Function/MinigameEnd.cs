using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class MinigameEnd : MonoBehaviour
{
    private static MinigameEnd instance = null;
    public static MinigameEnd Instance
    {
        get
        {
            instance = FindObjectOfType(typeof(MinigameEnd)) as MinigameEnd;
            return instance;
        }
    }

    public void PassMinigameValue(BigInteger value)
    {
        PlayerPrefs.SetString("minigame coin", value.ToString());
    }
}
