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
        
        if(dropCard.GetComponent<MovingCard>().CanMoving && dropCard.GetComponent<MovingCard>().isActive)
        {
            dropCard.transform.SetParent(transform);
            dropCard.GetComponent<RectTransform>().position = transform.position;

            var field = gameObject.GetComponent<BoardField>();
            if (field != null)
                    GameObject.Find("ManagerGame").GetComponent<ManagerGame>().Area.PutNewCard(field.PositionInGrid);

            GameObject.Find("ManagerGame").GetComponent<ManagerGame>().EndMovePlayer();
        }
    }
}
