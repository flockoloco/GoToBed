using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handplacementscript : MonoBehaviour
{
    [SerializeField]    
    GameObject _pivotPoint;

    public  void aaaaaa()
    {
        gameObject.transform.rotation = _pivotPoint.transform.rotation;
        gameObject.transform.position = _pivotPoint.transform.position;


    }
}
