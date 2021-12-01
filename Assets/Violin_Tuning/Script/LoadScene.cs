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
       // MinigameEnd.Instance.PassMinigameValue(10000);
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
