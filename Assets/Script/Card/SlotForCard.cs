using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class SlotForCard : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var dropCard = eventData.pointerDrag;

        foreach (Transform item in transform)
        {
            if (!item.GetComponent<Card>() != null)
                return;
        }
        
        if(dropCard.GetComponent<MovingCard>().CanMoving)
        {
            dropCard.transform.SetParent(transform);
            dropCard.GetComponent<RectTransform>().position = transform.position;
        }
    }
}
