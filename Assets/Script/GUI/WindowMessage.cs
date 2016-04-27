using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class WindowMessage : MonoBehaviour {

    public GameObject ButtonPrefab;
    public GameObject ButtonsPanel;
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

        CleanButtonsPanel();
        var button = Instantiate(ButtonPrefab);
        button.GetComponent<ButtonWindow>().Text.text = "OK";
        button.GetComponent<Button>().onClick.AddListener(() => { CloseWindow(); });
        button.transform.SetParent(ButtonsPanel.transform);
    }

    public void ShowMessage(string text, int fontSize, Action evenAfterClick)
    {
        this.evenAfterClick = evenAfterClick;
        SetBasicParameters(text, fontSize);
        gameObject.SetActive(true);

        CleanButtonsPanel();
        var button = Instantiate(ButtonPrefab);
        button.GetComponent<ButtonWindow>().Text.text = "OK";
        button.GetComponent<Button>().onClick.AddListener(() => { evenAfterClick(); });
        button.transform.SetParent(ButtonsPanel.transform);
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);

        if(evenAfterClick != null)
        {
            evenAfterClick();
            evenAfterClick = null;
        }
            
    }

    void SetBasicParameters(string text, int fontSize)
    {
        TextPref.text = text;
        TextPref.fontSize = fontSize;
    }

    void CleanButtonsPanel()
    {
        foreach (Transform child in ButtonsPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
