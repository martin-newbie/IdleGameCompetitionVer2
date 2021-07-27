using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> NoteList = new List<GameObject>();

    [SerializeField] Transform Center = null;
    [SerializeField] Transform Up = null;
    [SerializeField] Transform Down = null;
    [SerializeField] Transform Left = null;
    [SerializeField] Transform Right = null;
    public Text Hit;
    [SerializeField] Text Score;
    public Image Hp;

    Vector2[] timingBox = null;
    float score = 0;
    public int combo = 1;
    public float hp;
    public float maxhp = 200;

    void Start()
    {
        hp = maxhp;
        timingBox = new Vector2[4];

        timingBox[0].Set(Center.position.y - 0.1f, Center.position.y + 0.1f);
        timingBox[1].Set(Center.position.y - 0.3f, Center.position.y + 0.3f);
        timingBox[2].Set(Center.position.y - 0.6f, Center.position.y + 0.6f);
        timingBox[3].Set(Center.position.y - 1.2f, Center.position.y + 1.2f);
    }

    void Update()
    {
        if (hp > maxhp)
            hp = maxhp;
        Hp.fillAmount = Mathf.Lerp(Hp.fillAmount, hp / maxhp, Time.deltaTime*5);
    }

    public void CheakTiming(int type)
    {
        for (int i = 0; i < NoteList.Count; i++)
        {
            float NotePosX = NoteList[i].transform.position.x;
            float NotePosY = NoteList[i].transform.position.y;

            for (int y = 0; y < timingBox.Length; y++)
            {
                if (timingBox[y].x <= NotePosY && NotePosY <= timingBox[y].y)
                {
                    switch (type)
                    {
                        case 0:
                            if (NotePosX == Up.position.x)
                            {
                                Destroy(NoteList[i]);
                                NoteList.RemoveAt(i);
                                switch (y)
                                {
                                    case 0:
                                        Hit.text = "Perfect";
                                        combo++;
                                        hp += 5;
                                        StartCoroutine(AddScore(score + 300, score));
                                        break;
                                    case 1:
                                        Hit.text = "Cool";
                                        combo++;
                                        hp += 3;
                                        StartCoroutine(AddScore(score + 200, score));
                                        break;
                                    case 2:
                                        Hit.text = "Good";
                                        combo++;
                                        hp += 2;
                                        StartCoroutine(AddScore(score + 100, score));
                                        break;
                                    case 3:
                                        Hit.text = "Bad";
                                        combo++;
                                        hp += 1;
                                        StartCoroutine(AddScore(score + 50, score));
                                        break;
                                }
                                return;
                            }
                            break;
                        case 1:
                            if (NotePosX == Down.position.x)
                            {
                                Destroy(NoteList[i]);
                                NoteList.RemoveAt(i);
                                switch (y)
                                {
                                    case 0:
                                        Hit.text = "Perfect";
                                        combo++;
                                        hp += 5;
                                        StartCoroutine(AddScore(score + 300, score));
                                        break;
                                    case 1:
                                        Hit.text = "Cool";
                                        combo++;
                                        hp += 3;
                                        StartCoroutine(AddScore(score + 200, score));
                                        break;
                                    case 2:
                                        Hit.text = "Good";
                                        combo++;
                                        hp += 2;
                                        StartCoroutine(AddScore(score + 100, score));
                                        break;
                                    case 3:
                                        Hit.text = "Bad";
                                        combo++;
                                        hp += 1;
                                        StartCoroutine(AddScore(score + 50, score));
                                        break;
                                }
                                return;
                            }
                            break;
                        case 2:
                            if (NotePosX == Left.position.x)
                            {
                                Destroy(NoteList[i]);
                                NoteList.RemoveAt(i);
                                switch (y)
                                {
                                    case 0:
                                        Hit.text = "Perfect";
                                        combo++;
                                        hp += 5;
                                        StartCoroutine(AddScore(score + 300, score));
                                        break;
                                    case 1:
                                        Hit.text = "Cool";
                                        combo++;
                                        hp += 3;
                                        StartCoroutine(AddScore(score + 200, score));
                                        break;
                                    case 2:
                                        Hit.text = "Good";
                                        combo++;
                                        hp += 2;
                                        StartCoroutine(AddScore(score + 100, score));
                                        break;
                                    case 3:
                                        Hit.text = "Bad";
                                        combo++;
                                        hp += 1;
                                        StartCoroutine(AddScore(score + 50, score));
                                        break;
                                }
                                return;
                            }
                            break;
                        case 3:
                            if (NotePosX == Right.position.x)
                            {
                                Destroy(NoteList[i]);
                                NoteList.RemoveAt(i);
                                switch (y)
                                {
                                    case 0:
                                        Hit.text = "Perfect";
                                        combo++;
                                        hp += 5;
                                        StartCoroutine(AddScore(score + 300, score));
                                        break;
                                    case 1:
                                        Hit.text = "Cool";
                                        combo++;
                                        hp += 3;
                                        StartCoroutine(AddScore(score + 200, score));
                                        break;
                                    case 2:
                                        Hit.text = "Good";
                                        combo++;
                                        hp += 2;
                                        StartCoroutine(AddScore(score + 100, score));
                                        break;
                                    case 3:
                                        Hit.text = "Bad";
                                        combo++;
                                        hp += 1;
                                        StartCoroutine(AddScore(score + 50, score));
                                        break;
                                }
                                return;
                            }
                            break;
                    }
                }
            }
        }
        combo = 0;
        hp -= 5;
        Hit.text = "Miss";
        Debug.Log("miss");
    }

    IEnumerator AddScore(float target, float current)
    {
        float duration = 0.6f;
        float offset = (target - current) / duration;

        score += (target - score) + (combo * 3);

        while (current < target)
        {
            current += offset * Time.deltaTime;
            Score.text = ((int)current).ToString();
            yield return null;
        }
        current = target;
        Score.text = ((int)current).ToString();
    }
}

