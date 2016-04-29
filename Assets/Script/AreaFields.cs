using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AreaFields : MonoBehaviour
{

    public GameObject EmptyField;
    public int Columns;
    public int Rows;
    public int WidthField;
    public int HeightField;
    public int SlotSpaceBetween;
    public List<GameObject> ListOfFields;

    public List<Player> ListPlayer;

    // Use this for initialization
    void Start()
    {
        RectTransform rectControl = gameObject.GetComponent<RectTransform>();

        int widthPanel = Columns * WidthField; // (WidthField + SlotSpaceBetween) + SlotSpaceBetween;     
        rectControl.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, widthPanel);

        int heightPanel = Rows * HeightField; // (HeightField + SlotSpaceBetween) + HeightField;
        rectControl.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightPanel);

        GridLayoutGroup gridLayout = gameObject.GetComponent<GridLayoutGroup>();
        gridLayout.cellSize = new Vector2(WidthField, HeightField);
        //gridLayout.spacing = new Vector2(SlotSpaceBetween, SlotSpaceBetween);

        fillEmptySlots();
    }

    public bool IsFullArea()
    {
        int numberFoundCard = 0;
        foreach (var field in ListOfFields)
        {
            foreach (Transform item in field.transform)
            {
                if (item.GetComponent<Card>() != null)
                {
                    numberFoundCard++;
                    continue;
                }
            }
        }

        if (numberFoundCard == ListOfFields.Count)
            return true;
        else
            return false;
    }

    private void fillEmptySlots()
    {
        ListOfFields = new List<GameObject>();
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                GameObject newSlot = Instantiate(EmptyField);
                newSlot.transform.SetParent(transform);
                RectTransform rect = newSlot.GetComponent<RectTransform>();
                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, WidthField);
                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, HeightField);

                newSlot.GetComponent<BoardField>().PositionInGrid = new Vector2(j, i);

                ListOfFields.Add(newSlot);
            }
        }
    }

    public void InitializePlayers(ref List<Player> listPlayer)
    {
        ListPlayer = listPlayer;
    }

    public void UpdateScoreForPlayers()
    {
        //TODO: DO PRZEROBIENIA !!!!!!!!!!!!!!!!!!!!!!!

        foreach (var player in ListPlayer)
        {
            player.Score = 0;
        }

        foreach (var field in ListOfFields)
        {
            foreach (Transform item in field.transform)
            {
                var card = item.GetComponent<Card>();
                if (card != null)
                {
                    if (card.ColorShield == ListPlayer[0].Color)
                        ListPlayer[0].Score++;
                    else
                        ListPlayer[1].Score++;
                }
            }
        }

        var managar = GameObject.Find("ManagerGame").GetComponent<ManagerGame>();

        ListPlayer[0].Score += managar.HandPlayerOne.GetComponent<Hand>().GetCountCards();
        ListPlayer[1].Score += managar.HandPlayerTwo.GetComponent<Hand>().GetCountCards();
    }

    public void PutNewCard(Vector2 position)
    {
        if (GetCardbyPosition(position) != null)
        {
            
            Card currentCard = GetCardbyPosition(position);
            if (GetCardbyPosition(position + new Vector2(0, 1)) != null)
            {
                // sprawdza pozycja niżej
                Card card = GetCardbyPosition(position + new Vector2(0, 1));
                if (card.ColorShield == currentCard.ColorShield) return;

                if (currentCard.BottNumerValue > card.TopNumerValue)
                    card.ColorShield = currentCard.Owner.Color;
                else if (currentCard.BottNumerValue < card.TopNumerValue)
                    currentCard.ColorShield = card.Owner.Color;
            }
            if (GetCardbyPosition(position + new Vector2(1, 0)) != null)
            {
                // pozycja po prawej
                Card card = GetCardbyPosition(position + new Vector2(1, 0));
                if (card.ColorShield == currentCard.ColorShield) return;

                if (currentCard.RightNumerValue > card.LeftNumerValue)
                    card.ColorShield = currentCard.Owner.Color;
                else if (currentCard.RightNumerValue < card.LeftNumerValue)
                    currentCard.ColorShield = card.Owner.Color;
            }
            if (GetCardbyPosition(position + new Vector2(0, -1)) != null)
            {
                // pozycja wyżej
                Card card = GetCardbyPosition(position + new Vector2(0, -1));
                if (card.ColorShield == currentCard.ColorShield) return;

                if (currentCard.TopNumerValue > card.BottNumerValue)
                    card.ColorShield = currentCard.Owner.Color;
                else if (currentCard.TopNumerValue < card.BottNumerValue)
                    currentCard.ColorShield = card.Owner.Color;
            }
            if (GetCardbyPosition(position + new Vector2(-1, 0)) != null)
            {
                // pozycja z lewej
                Card card = GetCardbyPosition(position + new Vector2(-1, 0));
                if (card.ColorShield == currentCard.ColorShield) return;

                if (currentCard.LeftNumerValue > card.RightNumerValue)
                    card.ColorShield = currentCard.Owner.Color;
                else if (currentCard.LeftNumerValue < card.RightNumerValue)
                    currentCard.ColorShield = card.Owner.Color;
            }
        }
    }

    public Card GetCardbyPosition(Vector2 position)
    {
        foreach (var field in ListOfFields)
        {
            if(field.GetComponent<BoardField>().PositionInGrid == position)
            {
                foreach (Transform item in field.transform)
                {
                    if (item.GetComponent<Card>() != null)
                    {
                        return item.GetComponent<Card>();
                    }
                }
            }
        }
        return null;
    }

}
