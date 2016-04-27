using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Internal;

public class ScoreBoard : MonoBehaviour {
    public GameObject shieldLeft;
    public GameObject shieldRight;
    public GameObject sliderLeft;
    public GameObject sliderRight;
    public GameObject sliderGameObject;
    public Text textLeft;
    public Text textRight;
    Vector3 tempVector;

    public int pL;
    public int pR;

    public float sliderValue
    {
        get { return sliderGameObject.GetComponent<Slider>().value; }
        set { sliderGameObject.GetComponent<Slider>().value = value; }
    }
    public Color leftColor
    {
        set
        {
            shieldLeft.GetComponent<Image>().color = value;
            sliderLeft.GetComponent<Image>().color = value;
        }
    }
    public Color rightColor
    {
        set
        {
            shieldRight.GetComponent<Image>().color = value;
            sliderRight.GetComponent<Image>().color = value;
        }
    }

    public void setScore(int playerLeft,int playerRight)
    {
        float tempFloat=0;
        if (playerLeft == 0 && playerRight != 0)
        {
             tempFloat = 1f;
        }
        else if (playerRight == 0 && playerLeft != 0)
        {
            tempFloat = 0;
        }
        else if (playerLeft == playerRight)
        {
            tempFloat = 0.5f;
        }
        else if (playerLeft > playerRight)
        {
            tempFloat = 1f -  ((float)playerRight / (float)(playerLeft+playerRight));
        }
        else if (playerLeft < playerRight)
        {
            tempFloat = (float)playerLeft / (float)(playerLeft + playerRight);
        }
        textLeft.text = playerLeft.ToString();
        textRight.text = playerRight.ToString();
        sliderValue = tempFloat;
    }

    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        setScore(pL, pR);
	}
}
