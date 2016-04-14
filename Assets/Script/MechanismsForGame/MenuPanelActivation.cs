using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPanelActivation : MonoBehaviour {
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseEnter()
    {
        anim.SetTrigger("ActivatePanel");
    }
    void OnMouseExit()
    {
        anim.SetTrigger("DeactivatePanel");
    }

    //this will change later on to lunch scene given by string
    public void LunchSceneMain()
    {
        SceneManager.LoadScene("Main");
    }
}
