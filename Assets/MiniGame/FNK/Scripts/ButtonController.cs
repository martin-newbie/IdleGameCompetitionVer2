using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    GameManager gameManager;
    public KeyCode KeyToPress;
    public int Keytype;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Awake()
    {

    }

    void Update()
    {
        switch(Keytype)
        {
            case 0:
                if (Input.GetKeyDown(KeyToPress))
                {
                    Debug.Log("up");
                    gameManager.CheakTiming(0);
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyToPress))
                {
                    Debug.Log("down");
                    gameManager.CheakTiming(1);
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyToPress))
                {
                    Debug.Log("left");
                    gameManager.CheakTiming(2);
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyToPress))
                {
                    Debug.Log("right");
                    gameManager.CheakTiming(3);
                }
                break;
        }
    }
}
