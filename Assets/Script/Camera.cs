using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public float _MoveSpeed=20;
	public float _ScrollSpeed=5;
    public float _InitialZoom = -300;
	private int _Border =1;
    public bool _BorderScrollingEnabled = false;
    public bool _ZoomScrollingEnabled = true;
    public bool _KeyboardCameraScrolling = true;
    public float _InitialStartingX = 330;
    public float _InitialStartingY = 250;
	private float _zoomInLimit=-200;
	private float _zoomOutLimit=-900;

	// Use this for initialization
	void Start () {
		transform.position=new Vector3(_InitialStartingX,_InitialStartingY,_InitialZoom);
	}
	
	// Update is called once per frame
	void Update () {
        BorderScrolling();
        ZoomScrolling();
        CameraScrollingKeyboard();
	}

    public void ZoomScrolling()
    {
        if (_ZoomScrollingEnabled)
        {
            if (this.transform.position.z < _zoomInLimit && this.transform.position.z > _zoomOutLimit)
            {
                transform.Translate(Vector3.forward * _ScrollSpeed * Input.GetAxis("Mouse ScrollWheel"), Space.World);
            }
            else if (this.transform.position.z >= _zoomInLimit && Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                transform.Translate(Vector3.forward * _ScrollSpeed * Input.GetAxis("Mouse ScrollWheel"), Space.World);
            }
            else if (this.transform.position.z <= _zoomOutLimit && Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                transform.Translate(Vector3.forward * _ScrollSpeed * Input.GetAxis("Mouse ScrollWheel"), Space.World);
            }
        }
    }
    public void CameraScrollingKeyboard()
    {
        if (_KeyboardCameraScrolling)
        {
            var AxisX = Input.GetAxis("Horizontal");
            var AxisY = Input.GetAxis("Vertical");
            if (AxisX != 0)
            {
                transform.Translate(Vector3.right * AxisX*1000 * Time.deltaTime, Space.World);
            }
            if (AxisY != 0)
            {
                transform.Translate(Vector3.up * AxisY* 1000 * Time.deltaTime, Space.World);
            }

        }
    }

    public void BorderScrolling()
    {
        if (_BorderScrollingEnabled)
        {
            var _MouseX = Input.mousePosition.x;
            var _MouseY = Input.mousePosition.y;
            if (_MouseX < _Border)
            {
                transform.Translate(Vector3.right * -_MoveSpeed * Time.deltaTime, Space.World);
            }
            if (_MouseX >= Screen.width - _Border)
            {
                transform.Translate(Vector3.right * _MoveSpeed * Time.deltaTime, Space.World);
            }
            if (_MouseY < _Border)
            {
                transform.Translate(Vector3.up * -_MoveSpeed * Time.deltaTime, Space.World);
            }
            if (_MouseY >= Screen.height - _Border)
            {
                transform.Translate(Vector3.up * _MoveSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
