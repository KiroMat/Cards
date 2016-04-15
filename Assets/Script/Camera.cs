using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public float _MoveSpeed=20;
	public float _ScrollSpeed=5;
	private int _Border =1;
	private float _zoomInLimit=-200;
	private float _zoomOutLimit=-900;
	// Use this for initialization
	void Start () {
		transform.position=new Vector3(this.transform.position.x,this.transform.position.y,-950);
	}
	
	// Update is called once per frame
	void Update () {
		var _MouseX = Input.mousePosition.x;
		var _MouseY = Input.mousePosition.y;
		if (_MouseX < _Border){
			transform.Translate(Vector3.right * -_MoveSpeed * Time.deltaTime,Space.World);
		}
		if (_MouseX >= Screen.width-_Border){
			transform.Translate(Vector3.right * _MoveSpeed * Time.deltaTime,Space.World);
		}
		if (_MouseY < _Border){
			transform.Translate(Vector3.up * -_MoveSpeed * Time.deltaTime,Space.World);
		}
		if (_MouseY >= Screen.height-_Border){
			transform.Translate(Vector3.up * _MoveSpeed * Time.deltaTime,Space.World);
		}
//to correct
        if (this.transform.position.z < _zoomInLimit && this.transform.position.z > _zoomOutLimit)
        {
            transform.Translate(Vector3.forward * _ScrollSpeed * Input.GetAxis("Mouse ScrollWheel"), Space.World);
        }
        else if (this.transform.position.z > _zoomInLimit && Input.GetAxis("Mouse ScrollWheel")<0)
        {
            transform.Translate(Vector3.forward * _ScrollSpeed * Input.GetAxis("Mouse ScrollWheel"), Space.World);
        }
        else if (this.transform.position.z < _zoomOutLimit && Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.Translate(Vector3.forward * _ScrollSpeed * Input.GetAxis("Mouse ScrollWheel"), Space.World);
        }
	}
}
