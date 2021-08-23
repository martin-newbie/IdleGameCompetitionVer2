using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource background;

    public AudioClip[] bgMusic;

    void Start()
    {
        BackgroundSfx();
    }

    void Update()
    {
    }

    public void SfxPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.clip = clip;
        audiosource.Play();
        Destroy(go, clip.length);
    }

    public void BackgroundSfx()
    {
        background.clip = bgMusic[(int)MainGameManager.Instance.curMap];
        background.Play();
    }
}
