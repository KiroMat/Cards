using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Hand : MonoBehaviour {

    public Transform emptySlot;
    private Transform lastCardOnTop;
    public List<Card> cardsInHand = new List<Card>();
    public Hand()
    {

    }
    public Hand(List<Card> cardsList)
    {
        cardsInHand = cardsList;
    }

    //change hoveredOver layout element to ignore
    //replace hoveredOver place in hierarchy by emptySlot
    //after mouseExit revert ->set emptySlot as last and hoveredOver as emptySlot



}
