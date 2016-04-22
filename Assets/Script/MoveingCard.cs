using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class MoveingCard : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform emptySlotInHeand = null;
    int sibliIndex = 0;

    public void OnPointerEnter(PointerEventData eventData)
    {
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
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
