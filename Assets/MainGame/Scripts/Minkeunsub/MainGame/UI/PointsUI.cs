using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    public GameObject[] Desces;
    void Start()
    {
        Initialize();
    }

    void Update()
    {
        
    }

    void Initialize()
    {
        for (int i = 0; i < Desces.Length; i++)
        {
            Desces[i].SetActive(false);
        }
    }

    public void PointSelect(int n)
    {
        Initialize();
        Desces[n].SetActive(true);
    }

    public void InitialButton()
    {
        Initialize();
    }
}
