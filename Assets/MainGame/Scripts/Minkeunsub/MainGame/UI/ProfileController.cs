using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ProfileController : MonoBehaviour
{
    [Header("Sprite")]
    public Sprite characterImg;
    public Sprite[] characterPostsSprite;

    [Header("string")]
    public string characterName;
    public string characterDesc;

    [Header("integer")]
    public int characterPosts;
    public int characterFollwer;
    public int characterFollowing;

    [Header("objects")]
    public Image characterProfile;
    public Image[] characterPost;
    public TextMeshProUGUI T_characterName;
    public TextMeshProUGUI T_characterDescc;
    public TextMeshProUGUI T_characterPosts;
    public TextMeshProUGUI T_characterFollower;
    public TextMeshProUGUI T_characterFollowing;

    [Header("position")]
    public RectTransform Pos;
    Vector3 curPos;


    // Start is called before the first frame update
    void Start()
    {
        characterPostsSprite = new Sprite[characterPost.Length];
        curPos = this.gameObject.transform.position;
        gameObject.transform.position = Pos.position;
    }

    // Update is called once per frame
    void Update()
    {
        AssignValue();
    }

    void AssignValue()
    {
        characterProfile.sprite = characterImg;
        for (int i = 0; i < characterPostsSprite.Length; i++)
        {
            characterPost[i].sprite = characterPostsSprite[i];
        }
        T_characterName.text = characterName;
        T_characterDescc.text = characterDesc;
        T_characterPosts.text = characterPosts.ToString();
        T_characterFollower.text = characterFollwer.ToString();
        T_characterFollowing.text = characterFollowing.ToString();
    }

    public void UIon()
    {
        gameObject.transform.DOMove(curPos, 0.5f, false);
    }

    public void UIoff()
    {
        gameObject.transform.DOMove(Pos.position, 0.5f, false);
    }
}
