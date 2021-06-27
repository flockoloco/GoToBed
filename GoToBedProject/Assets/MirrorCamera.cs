using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCamera : MonoBehaviour
{
    public Transform playerCamera;

    private void Update()
    { 
        transform.LookAt(playerCamera, Vector3.up);
    }
}
