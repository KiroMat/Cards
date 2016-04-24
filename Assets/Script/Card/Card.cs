using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    #region CardElementsReferences
    public GameObject ShieldInPref;
    public GameObject BackgroundPref;
    public GameObject AvatarImagePref;
    public GameObject NamePref;
    public GameObject TopNumberPref;
    public GameObject BottNumberPref;
    public GameObject LeftNumberPref;
    public GameObject RightNumberPref;
    #endregion

    #region Setters&Getters

    public Color ColorShield
    {
        set
        {
            if (ShieldInPref != null)
                ShieldInPref.GetComponent<Image>().color = value;
        }
    }

    //getters for numbers
    public int TopNumerValue
    {
        get { return int.Parse(TopNumberPref.GetComponent<Text>().text); }
        set { TopNumberPref.GetComponent<Text>().text = value.ToString(); }
    }
    public int BottNumerValue
    {
        get { return int.Parse(BottNumberPref.GetComponent<Text>().text); }
        set { BottNumberPref.GetComponent<Text>().text = value.ToString(); }
    }
    public int LeftNumerValue
    {
        get { return int.Parse(LeftNumberPref.GetComponent<Text>().text); }
        set { LeftNumberPref.GetComponent<Text>().text = value.ToString(); }
    }
    public int RightNumerValue
    {
        get { return int.Parse(RightNumberPref.GetComponent<Text>().text); }
        set { RightNumberPref.GetComponent<Text>().text = value.ToString(); }
    }
    //setter & getter for Name of the card
    public string CardName
    {
        get { return NamePref.GetComponent<Text>().text; }
        set { NamePref.GetComponent<Text>().text = value; }
    }

    //setters for AvatarImage, background and Shield
    public Sprite AvatarImg
    {
        set { AvatarImagePref.GetComponent<Image>().sprite = value; }
    }
    public Sprite BackgroundImg
    {
        set { BackgroundPref.GetComponent<Image>().sprite = value; }
    }
    #endregion


}
