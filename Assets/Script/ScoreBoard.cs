using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
    public GameObject activePlayerParticle;
    public GameObject shieldLeft;
    public GameObject shieldRight;
    public GameObject sliderLeft;
    public GameObject sliderRight;
    public GameObject sliderGameObject;

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

    void Start () {
        rightColor = Color.green;
        leftColor = Color.cyan;
        sliderValue = 0.8f;
	}
	
	// Update is called once per frame
	void Update () {
    //    activePlayerParticle.transform.position = 
	}
}
