using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handplacementscript : MonoBehaviour
{
    [SerializeField]    
    GameObject _pivotPoint;

    public void HandToPivotTranslate()
    {
        Debug.Log("aaaaaaaaaaaaaaa");
        gameObject.transform.rotation = _pivotPoint.transform.parent.rotation;
        gameObject.transform.position = _pivotPoint.transform.parent.position;


    }
}
