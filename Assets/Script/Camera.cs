using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    private float _MoveSpeed = 0.1f;
    private float _ScrollSpeed = 80f;
    public float _ZoomSpeedFactor = 10f;
    public float _InitialZoom = -300;
    private int _Border = 1; // border for scrolling camera with mouse close to borders
    public bool _BorderScrollingEnabled;
    public bool _ZoomScrollingEnabled = true;
    public bool _KeyboardCameraScrolling = true;
    public bool _CameraDragEnabled;
    public float _InitialStartingX = 330;
    public float _InitialStartingY = 250;
    private float _zoomInLimit = -200;
    private float _zoomOutLimit = -900;
    private Vector3 dragOrigin;
    public GameObject boardPrefabForBorders;    //Here drop your GUI element that you want your camera to be locked onto
    //camera bounds that it cannot cross while scrolling
    private float borderXmax;
    private float borderXmin;
    private float borderYmax;
    private float borderYmin;

    // Use this for initialization
    void Start() {
        transform.position = new Vector3(_InitialStartingX, _InitialStartingY, _InitialZoom);
 
    }

    // Update is called once per frame
    void Update() {
        if (_BorderScrollingEnabled)
        {
            BorderScrolling();
        }
        if (_ZoomScrollingEnabled)
        {
            ZoomScrolling();
        }
        if (_KeyboardCameraScrolling)
        {
            CameraScrollingKeyboard();
        }
        if (_CameraDragEnabled)
        {
            CameraDrag();
        }
    }

    private void ZoomScrolling()
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
    private void CameraScrollingKeyboard()
    {

        var AxisX = Input.GetAxis("Horizontal");
        var AxisY = Input.GetAxis("Vertical");
        if (AxisX != 0)
        {
            if (AxisX > 0 && UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).x < borderXmax || AxisX < 0 && UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x > borderXmin)
            {
                transform.Translate(Vector3.right * AxisX * 1000 * Time.deltaTime, Space.World);
            }
        }
        if (AxisY != 0)
        {
            if (AxisY > 0 && UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).y < borderYmax)
            {
                transform.Translate(Vector3.up * AxisY * 1000 * Time.deltaTime, Space.World);
            }
            else if (AxisY < 0 &&  UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y > borderYmin)
            {
                transform.Translate(Vector3.up * AxisY * 1000 * Time.deltaTime, Space.World);
            }
        }
        
    }
    private void BorderScrolling()
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

    private void CameraDrag()
    {
        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(1)) return;
        Vector3 pos = Input.mousePosition - dragOrigin;
        Vector3 move = new Vector3(pos.x * _MoveSpeed, pos.y * _MoveSpeed, 0);
        if (move.x > 0 && UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).x >= borderXmax  || move.x < 0 && UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x <= borderXmin)
            move.x = 0;
        if (move.y > 0 && UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).y >= borderYmax  || move.y < 0 && UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y <= borderYmin)
            move.y=0;

        transform.Translate(move, Space.Self);
    }

    public void SetScrollingBorders()
    {
        int partofscreen = 8;
        RectTransform tempRect = boardPrefabForBorders.GetComponent<RectTransform>();
        borderXmax = tempRect.position.x+(tempRect.rect.width/2)+(Screen.width/partofscreen);
        borderXmin = tempRect.position.x - (tempRect.rect.width / 2) - (Screen.width / partofscreen);
        borderYmax = tempRect.position.y + (tempRect.rect.height / 2) + (Screen.height / partofscreen);
        borderYmin = tempRect.position.x - (tempRect.rect.height / 2) - (Screen.height / partofscreen);
    }
}

