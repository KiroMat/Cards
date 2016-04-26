using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player {
    public string  NamePlayer { get; set; }
    public int Score { get; set; }
    public int Wins { get; set; }
    public List<GameObject> Cards { get; set; }

    private bool isActive;
    public bool IsActive
    {
        get { return isActive; }
        set
        {
            isActive = value;
            ChangeActiveAllCards();
        }
    }

    private Color color;
    public Color Color
    {
        get { return color; }
        set
        {
            color = value;
            ChangeColorCards();
        }
    }

    public Player()
    {
        //TODO: jest to do usunięcia ponieważ gracz nie bedzie później generował tali lecz ją składał
        var generatorCards = GameObject.FindGameObjectWithTag("CardGenerator").GetComponent<GeneratorCards>();

        Cards = generatorCards.GetListOfCards();
        foreach (var card in Cards)
        {
            card.GetComponent<Card>().Owner = this;
        }

        NamePlayer = generatorCards.GenerateName();
    }

    void ChangeColorCards()
    {
        foreach (var card in Cards)
        {
            card.GetComponent<Card>().ColorShield = color;
        }
    }

    void ChangeActiveAllCards()
    {
        foreach (var card in Cards)
        {
            card.GetComponent<MovingCard>().isActive = IsActive;
        }
    }
}
