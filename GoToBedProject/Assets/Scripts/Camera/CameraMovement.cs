using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 180f;
    public Transform playerBody;
    private float cameraXAxis = 0f;
    private float cameraYAxis = 0f;
    [SerializeField]
    private handplacementscript _handObjecScript;
    [SerializeField]
    private int _cameraState;
    [SerializeField]
    private PlayerStats playerStats;

    public int CameraState { get => _cameraState; set => _cameraState = value; }

    public static void setMouseLock(bool locked)
    {
        if (locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    private void Start()
    {
        setMouseLock(true);
    }

    

    void OnPreRender()
    {
        _handObjecScript.HandToPivotTranslate();
    }




    // Update is called once per frame
    void LateUpdate()
    {
        if (_cameraState.Equals(1))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                float mouseYInput = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
                float mouseXInput = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                cameraXAxis -= mouseYInput;
                //cameraYAxis += mouseXInput;
                cameraXAxis = Mathf.Clamp(cameraXAxis, -90f, 90f);
                transform.localEulerAngles = new Vector3(cameraXAxis, 0f, 0f);
                playerBody.Rotate(Vector3.up * mouseXInput);
            }
        }
        else if (_cameraState.Equals(2))
        {
            //mexer pouquinho
            float mouseYInput = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            float mouseXInput = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            cameraXAxis -= mouseYInput;
            cameraYAxis += mouseXInput;
            cameraXAxis = Mathf.Clamp(cameraXAxis, -45f, 45f);
            cameraYAxis = Mathf.Clamp(cameraYAxis, -45f, 45f);
            transform.localEulerAngles = new Vector3(cameraXAxis, cameraYAxis, 0f);
           // playerBody.Rotate(Vector3.up * mouseXInput);
        }
        else if (_cameraState.Equals(3))
        {
            //estou em animação não me toque não

        }
    }
}
