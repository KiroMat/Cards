using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AreaFields : MonoBehaviour {

    public GameObject EmptyField;
    public int Columns;
    public int Rows;
    public int WidthField;
    public int HeightField;
    public int SlotSpaceBetween;
    public List<GameObject> ListOfFields;

    // Use this for initialization
    void Start () {
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
        for (int i = 0; i < Columns; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                GameObject newSlot = Instantiate(EmptyField);
                newSlot.transform.SetParent(transform);
                RectTransform rect = newSlot.GetComponent<RectTransform>();
                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, WidthField);
                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, HeightField);

                newSlot.GetComponent<BoardField>().PositionInGrid = new Vector2(i, j);

                ListOfFields.Add(newSlot);
            }
        }
    }
}
