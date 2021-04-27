using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingObjectInfo : MonoBehaviour
{
    [SerializeField]
    Transform _entryPosition;
    [SerializeField]
    Transform _hiddenPosition;
    [SerializeField]
    typeOfHiding _hiddingAnimation;
    public enum typeOfHiding //move this out of here, put in modelling
    {
        Closet,
        Bed
            //....
    }
    public Transform EntryPosition { get => _entryPosition; set => _entryPosition = value; }
    public Transform HiddenPosition { get => _hiddenPosition; set => _hiddenPosition = value; }
    public typeOfHiding HiddingAnimation { get => _hiddingAnimation; set => _hiddingAnimation = value; }


    
}
