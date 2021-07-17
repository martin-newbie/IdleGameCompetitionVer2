using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NestedScrollManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar scrollbar;
    public Transform contentTr;

    const int SIZE = 4;
    float[] pos = new float[SIZE];
    float distance, targetpos, curpos;
    bool isDrag;
    int targetIndex;


    void Start()
    {
        distance = 1f / (SIZE - 1);
        for (int i = 0; i < SIZE; i++) pos[i] = distance * i;

    }

    float SetPos()
    {
        for (int i = 0; i < SIZE; i++)
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
            {
                targetIndex = i;
                return pos[i];
            }
        return 0;
    }

    public void OnBeginDrag(PointerEventData eventData) => curpos = SetPos();

    public void OnDrag(PointerEventData eventData) => isDrag = true;

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;

        targetpos = SetPos();

        if(curpos == targetpos)
        {
            if(eventData.delta.x > 18 && curpos - distance >= 0)
            {
                --targetIndex;
                targetpos = curpos - distance;
            }
            else if(eventData.delta.x < -18 && curpos + distance <= 1.01f)
            {
                ++targetIndex;
                targetpos = curpos + distance;
            }
        }

        for (int i = 0; i < SIZE; i++)
            if (contentTr.GetChild(i).GetComponent<ScrollScript>() && curpos != pos[i] && targetpos == pos[i])
                contentTr.GetChild(i).GetChild(1).GetComponent<Scrollbar>().value = 1;
    }

    void Update()
    {
        if (!isDrag) scrollbar.value = Mathf.Lerp(scrollbar.value, targetpos, 0.1f);

    }

    public void TabClick(int n)
    {
        targetIndex = n;
        targetpos = pos[n];
    }
}
