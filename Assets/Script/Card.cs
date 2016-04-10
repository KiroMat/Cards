using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card : MonoBehaviour {

    #region CardElementsReferences
    public GameObject Shield;
    public GameObject Background;
    public GameObject AvatarImage;
    public GameObject Name;
    public GameObject TopNumber;
    public GameObject BottNumber;
    public GameObject LeftNumber;
    public GameObject RightNumber;
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
        get { return int.Parse(LeftNumber.GetComponent<Text>().text; }
        set { LeftNumber.GetComponent<Text>().text = value.ToString(); }
    }
    public int RightNumerValue
    {
        get { return int.Parse(RightNumber.GetComponent<Text>().text; }
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
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    #endregion
}
