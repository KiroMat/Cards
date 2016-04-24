using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class MovingCard : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool CanMoving = false;

    Transform emptySlotInHeand = null;
    int sibliIndex = 0;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (transform.parent.GetComponent<BoardField>() != null)
            CanMoving = false;
        else
            CanMoving = true;

        var empty = transform.parent.GetComponent<Hand>();
        if(empty != null)
        {
            emptySlotInHeand = transform.parent.GetComponent<Hand>().emptySlot;
            emptySlotInHeand.transform.SetSiblingIndex(transform.GetSiblingIndex());
            GetComponent<LayoutElement>().ignoreLayout = true;
            sibliIndex = transform.GetSiblingIndex();
            transform.SetAsLastSibling();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(transform.parent.transform.parent.GetComponent<Hand>() != null)
        {
            emptySlotInHeand = null;
        }

        if (emptySlotInHeand != null)
        {
            transform.SetSiblingIndex(emptySlotInHeand.GetSiblingIndex());
            transform.SetSiblingIndex(sibliIndex);
            transform.GetComponent<LayoutElement>().ignoreLayout = false;
            emptySlotInHeand.transform.SetAsFirstSibling();
            emptySlotInHeand = null;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (CanMoving)
        {
            transform.position = eventData.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }   
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(CanMoving)
            transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(CanMoving)
            GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
