using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Carddd : MonoBehaviour, IMoveHandler, IBeginDragHandler, IEndDragHandler
{

    public void OnMove(AxisEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var ooo = eventData.pointerEnter.GetComponent<Slot>();
        if (ooo != null)
        {
            //ooo.cart = this;
        }

        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
