using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public GameObject ShieldInPref;
    public GameObject BackgroundPref;
    public GameObject AvatarImagePref;
    public GameObject NamePref;
    public GameObject TopNumberPref;
    public GameObject BottNumberPref;
    public GameObject LeftNumberPref;
    public GameObject RightNumberPref;

    public Color ColorShield
    {
        get { return ShieldInPref.GetComponent<Image>().color; }
        set
        {
            if (ShieldInPref != null)
                ShieldInPref.GetComponent<Image>().color = value;
        }
    }

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
    public string CardName
    {
        get { return NamePref.GetComponent<Text>().text; }
        set { NamePref.GetComponent<Text>().text = value; }
    }
    public Sprite AvatarImg
    {
        set { AvatarImagePref.GetComponent<Image>().sprite = value; }
    }
    public Sprite BackgroundImg
    {
        set { BackgroundPref.GetComponent<Image>().sprite = value; }
    }

    public Player Owner;
}
