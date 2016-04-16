using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class PointerEnterExitHand : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        var emptySlot = transform.parent.GetComponent<Hand>().emptySlot;
        GetComponent<LayoutElement>().ignoreLayout = true;
        emptySlot.transform.SetSiblingIndex(transform.GetSiblingIndex());
        transform.SetAsLastSibling();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        var emptySlot = transform.parent.GetComponent<Hand>().emptySlot;
        transform.SetSiblingIndex(emptySlot.GetSiblingIndex());
        transform.GetComponent<LayoutElement>().ignoreLayout = false;
        emptySlot.transform.SetAsFirstSibling();
    }
}
