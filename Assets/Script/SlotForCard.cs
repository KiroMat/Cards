﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class SlotForCard : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var dropCard = eventData.pointerDrag;

        dropCard.transform.SetParent(transform);
        dropCard.GetComponent<RectTransform>().position = transform.position;

    }
}
