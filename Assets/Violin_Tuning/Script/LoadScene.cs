using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Text Continue;

    public float ContinueTimer = 0;

    public void Start()
    {
        ContinueTimer = 5;
    }
    void Update()
    {
        Continuetime();  
    }
    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Continuetime()
    {
        if(ContinueTimer > 0)
        ContinueTimer -= Time.deltaTime;

        if (ContinueTimer < 0)
        LoadMainGame();

        Continue.text = "Continue? " + Mathf.Ceil(ContinueTimer).ToString();
    }
}
