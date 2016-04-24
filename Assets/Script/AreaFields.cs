using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class AreaFields : MonoBehaviour {

    public GameObject EmptyField;
    public int Columns;
    public int Rows;
    public int WidthField;
    public int HeightField;
    public int SlotSpaceBetween;


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
	
	// Update is called once per frame
	void Update () {
	
	}

    private void fillEmptySlots()
    {
        for (int i = 0; i < Columns * Rows; i++)
        {
            GameObject newSlot = Instantiate(EmptyField);
            newSlot.transform.SetParent(transform);
            RectTransform rect = newSlot.GetComponent<RectTransform>();
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, WidthField);
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, HeightField);

            //allSlots.Add(newSlot.GetComponent<InventorySlot>());
        }
    }
}
