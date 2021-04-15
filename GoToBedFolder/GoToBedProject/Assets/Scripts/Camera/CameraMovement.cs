using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 180f;
    private float cameraXAxis = 0;
    private float cameraYAxis = 0;
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
            float mouseYInput = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
            float mouseXInput = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
            cameraXAxis -= mouseYInput;
            cameraYAxis += mouseXInput;
            cameraXAxis = Mathf.Clamp(cameraXAxis, -90, 90);
            transform.localEulerAngles = new Vector3(cameraXAxis, cameraYAxis, 0f);
        }
    }
}
