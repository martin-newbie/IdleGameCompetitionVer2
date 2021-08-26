using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSelect : MonoBehaviour
{
    public int MusicNumber;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);   
    }
    public void GoMainGame()
    {
        SceneManager.LoadScene("MainGame");
        Destroy(gameObject);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("RhythmGame");
    }

    public void SelectMusic1()
    {
        MusicNumber = 1;
        LoadGame();
    }

    public void SelectMusic2()
    {
        MusicNumber = 2;
        LoadGame();
    }
    public void SelectMusic3()
    {
        MusicNumber = 3;
        LoadGame();
    }


}
