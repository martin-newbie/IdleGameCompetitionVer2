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
    }

    public void SelectMusic1()
    {
        MusicNumber = 1;
        SceneManager.LoadScene("RhythmGame");
    }

    public void SelectMusic2()
    {
        MusicNumber = 2;
        SceneManager.LoadScene("RhythmGame");
    }
    public void SelectMusic3()
    {
        MusicNumber = 3;
        SceneManager.LoadScene("RhythmGame");
    }
}
