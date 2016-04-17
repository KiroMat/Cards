using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Hand : MonoBehaviour {

    public Transform emptySlot;
    private Transform lastCardOnTop;
    public List<GameObject> cardsInHand = new List<GameObject>();

    void Start()
    {
        var gen = GameObject.FindGameObjectWithTag("CardGenerator").GetComponent<GeneratorCards>();
        if(gen != null)
        {
            cardsInHand = gen.GetListOfCards();

            foreach (var item in cardsInHand)
            {
                item.transform.parent = transform;
            }
        }
    }



}
