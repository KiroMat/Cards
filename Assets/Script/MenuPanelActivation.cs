using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MenuPanelActivation : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {
    private Animator anim;
	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}

    //this will change later on to lunch scene given by string
    public void LunchSceneMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetTrigger("ActivatePanel");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetTrigger("DeactivatePanel");
    }
}
