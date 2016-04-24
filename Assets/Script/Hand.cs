using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{

    public Transform emptySlot;
    private Transform lastCardOnTop;
    public List<GameObject> cardsInHand = new List<GameObject>();

    public void SetCartsInHand(List<GameObject> cards)
    {
        cardsInHand = new List<GameObject>();
        if (cards != null)
        {
            foreach (var item in cards)
            {
                item.transform.SetParent(transform);
                cardsInHand.Add(item);
            }
        }
    }
}
