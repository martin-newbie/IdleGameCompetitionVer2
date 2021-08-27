using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FNK_ScrollManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Scrollbar scrollbar;
    
    const int SIZE = 3;
    float[] pos = new float[SIZE];
    float distance;
    public float targetPos;
    bool isDrag;

    void Start()
    {
        distance = 1f / (SIZE - 1);
        for (int i = 0; i < SIZE; i++)
            pos[i] = distance * i;
        targetPos = 0.5f;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        for (int i = 0; i < SIZE; i++)
        {
            if(scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
            {
                targetPos = pos[i];
            }
        }
    }

    void Update()
    {
        if(!isDrag)
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);
    }
}
