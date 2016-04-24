using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WindowMessage : MonoBehaviour {

    public Text TextPref;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowMessage(string text, int fontSize)
    {
        TextPref.text = text;
        TextPref.fontSize = fontSize;
        gameObject.SetActive(true);
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }

}
