using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public delegate void ChangedEventHandler(Carddd name);

[Serializable]
public class Slot : MonoBehaviour  {

    public event ChangedEventHandler Changed;
  
    public int Amount;

    private Carddd card;

    public Carddd Card
    {
        set
        {
            if (card != null)
                return;

            card = value;
            Changed(card);
        }
    }

    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
