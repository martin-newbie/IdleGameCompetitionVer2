using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMusic : MonoBehaviour
{
    FNK_ScrollManager scrollManager;

    public int Music;

    void Start()
    {
        scrollManager = FindObjectOfType<FNK_ScrollManager>();
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (scrollManager.targetPos == 0f)
        {
            Music = 1; //TheHunter
        }
        else if (scrollManager.targetPos == 0.5f)
        {
            Music = 0; //GoRock
        }
        else if (scrollManager.targetPos == 1f)
        {
            Music = 2; //Cantina
        }
    }
}
