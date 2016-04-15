using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hand : MonoBehaviour {
    public Hand()
    {

    }
    public Hand(List<Card> cardsList)
    {
        cardsInHand = cardsList;
    }
    public List<Card> cardsInHand = new List<Card>();
   


}
