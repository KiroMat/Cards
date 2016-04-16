using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{

    #region CardElementsReferences
    public GameObject Shield;
    public GameObject Background;
    public GameObject AvatarImage;
    public GameObject Name;
    public GameObject TopNumber;
    public GameObject BottNumber;
    public GameObject LeftNumber;
    public GameObject RightNumber;
    public Hand handReference;
    #endregion
    #region ResourcesReferences
    public Sprite redShield;
    public Sprite blueShield;
    #endregion
    #region Setters&Getters
    //getters for numbers
    public int TopNumerValue
    {
        get { return int.Parse(TopNumber.GetComponent<Text>().text); }
        set { TopNumber.GetComponent<Text>().text = value.ToString(); }
    }
    public int BottNumerValue
    {
        get { return int.Parse(BottNumber.GetComponent<Text>().text); }
        set { BottNumber.GetComponent<Text>().text = value.ToString(); }
    }
    public int LeftNumerValue
    {
        get { return int.Parse(LeftNumber.GetComponent<Text>().text); }
        set { LeftNumber.GetComponent<Text>().text = value.ToString(); }
    }
    public int RightNumerValue
    {
        get { return int.Parse(RightNumber.GetComponent<Text>().text); }
        set { RightNumber.GetComponent<Text>().text = value.ToString(); }
    }
    //setter & getter for Name of the card
    public string CardName
    {
        get { return Name.GetComponent<Text>().text; }
        set { Name.GetComponent<Text>().text = value; }
    }

    //setters for AvatarImage, background and Shield
    public Sprite AvatarImg
    {
        set { AvatarImage.GetComponent<Image>().sprite = value; }
    }
    public Sprite BackgroundImg
    {
        set { Background.GetComponent<Image>().sprite = value; }
    }
    public Sprite ShieldImg
    {
        set { Shield.GetComponent<Image>().sprite = value; }
    }
    #endregion

    #region UnityMethods
 
    public void OnPointerEnter(PointerEventData eventData)
    {
        


        //handReference.CardOnTop(this.gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    
        //handReference.BackToPreviousOrder();
    }
    #endregion

}
