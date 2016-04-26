using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class WindowMessageManager : MonoBehaviour {

    public Text TextPref;

    private Action evenAfterClick;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowMessage(string text, int fontSize)
    {
        SetBasicParameters(text, fontSize);
        gameObject.SetActive(true);
    }

    public void ShowMessage(string text, int fontSize, Action evenAfterClick)
    {
        this.evenAfterClick = evenAfterClick;
        SetBasicParameters(text, fontSize);
        gameObject.SetActive(true);
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);

        if(evenAfterClick != null)
            evenAfterClick();
    }


    void SetBasicParameters(string text, int fontSize)
    {
        TextPref.text = text;
        TextPref.fontSize = fontSize;
    }
}
