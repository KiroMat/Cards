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
    public int GetTopNumber()
    {
        return int.Parse(TopNumber.GetComponent<Text>().text);
    }
    public int GetBottNumber()
    {
        return int.Parse(BottNumber.GetComponent<Text>().text);
    }
    public int GetLeftNumber()
    {
        return int.Parse(LeftNumber.GetComponent<Text>().text);
    }
    public int GetRightNumber()
    {
        return int.Parse(RightNumber.GetComponent<Text>().text);
    }
    //setters for numbers
    public void SetTopNumber(int number)
    {
        TopNumber.GetComponent<Text>().text = number.ToString();
    }
    public void SetBottNumber(int number)
    {
        BottNumber.GetComponent<Text>().text = number.ToString();
    }
    public void SetLeftNumber(int number)
    {
        LeftNumber.GetComponent<Text>().text = number.ToString();
    }
    public void SetRightNumber(int number)
    {
        RightNumber.GetComponent<Text>().text = number.ToString();
    }
    //setter & getter for Name of the card
    public void SetCardName(string name)
    {
        Name.GetComponent<Text>().text = name;
    }
    public string GetCardName()
    {
        return Name.GetComponent<Text>().text;
    }
    //setters for AvatarImage, background and Shield
    public void SetAvatarImage(Sprite image)
    {
        AvatarImage.GetComponent<Image>().sprite = image;
    }
    public void SetBackgroundImage(Sprite image)
    {
        Background.GetComponent<Image>().sprite = image;
    }
    public void SetShieldImage(Sprite image)
    {
        Shield.GetComponent<Image>().sprite = image;
    }
    #endregion

    #region UnityMethods
    // Use this for initialization
    void Start () {
        Debug.Log(GetCardName());
        SetCardName("Laps");
        Debug.Log(GetCardName());
        SetAvatarImage(blueShield);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    #endregion
}
