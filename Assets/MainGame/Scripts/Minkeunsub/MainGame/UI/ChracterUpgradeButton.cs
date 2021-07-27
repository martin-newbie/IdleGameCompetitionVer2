using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChracterUpgradeButton : UpgradeBtnBase
{

    [Header("character")]
    public GameObject character;

    [Header("information")]
    public Sprite characterSprite;
    public string characterName;
    public string characterDesc;
    public int characterPosts;
    public int characterFollwer;
    public int characterFollowing;

    public override void CharacterController()
    {
        character.SetActive(!locked);
    }

    public void ProfileBtn()
    {
        MainGameManager.Instance.profile.UIon();
        MainGameManager.Instance.profile.characterImg = characterSprite;
        MainGameManager.Instance.profile.characterName = characterName;
        MainGameManager.Instance.profile.characterDesc = characterDesc;
        MainGameManager.Instance.profile.characterPosts = characterPosts;
        MainGameManager.Instance.profile.characterFollwer = characterFollwer;
        MainGameManager.Instance.profile.characterFollowing = characterFollowing;
    }
}
