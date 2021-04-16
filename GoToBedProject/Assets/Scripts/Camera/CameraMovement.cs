using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 180f;
    public Transform playerBody;
    private float cameraXAxis = 0f;
    private float cameraYAxis = 0f;
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





    // Update is called once per frame
    void Update()
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
}
