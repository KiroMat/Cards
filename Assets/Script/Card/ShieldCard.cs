using UnityEngine;
using System.Collections;

public class ShieldCard : MonoBehaviour {

    public GameObject ShieldOut;
    public GameObject ShieldIn;

    public Color Color
    {
        set
        {
            ShieldIn.GetComponent<SpriteRenderer>().color = value;
        }
    }
}
