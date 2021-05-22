﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 180f;
    public Transform playerBody;
    [SerializeField]
    private float cameraXAxis = 0f;
    [SerializeField]
    private float cameraYAxis = 0f;
    [SerializeField]
    private handplacementscript _handObjecScript;
    [SerializeField]
    private int _cameraState;
    [SerializeField]
    private PlayerStats playerStats;

    public int CameraState { get => _cameraState; set => _cameraState = value; }
    public float CameraYAxis { get => cameraYAxis; set => cameraYAxis = value; }
    public float CameraXAxis { get => cameraXAxis; set => cameraXAxis = value; }

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
       if (Input.GetKey(KeyCode.C))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetKey(KeyCode.V))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (_cameraState.Equals(1))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                float mouseYInput = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
                float mouseXInput = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                CameraXAxis -= mouseYInput;
                //cameraYAxis += mouseXInput;
                CameraXAxis = Mathf.Clamp(CameraXAxis, -90f, 90f);
                transform.localEulerAngles = new Vector3(CameraXAxis, 0f, 0f);
                playerBody.Rotate(Vector3.up * mouseXInput);
            }
        }
        else if (_cameraState.Equals(2))
        {
            //mexer pouquinho
            float mouseYInput = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            float mouseXInput = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            CameraXAxis -= mouseYInput;
            CameraYAxis += mouseXInput;
            CameraXAxis = Mathf.Clamp(CameraXAxis, -45f, 45f);
            CameraYAxis = Mathf.Clamp(CameraYAxis, -45f, 45f);
            transform.localEulerAngles = new Vector3(CameraXAxis, CameraYAxis, 0f);
           // playerBody.Rotate(Vector3.up * mouseXInput);
        }
        else if (_cameraState.Equals(3))
        {
            //estou em animação não me toque não

        }
    }
}
