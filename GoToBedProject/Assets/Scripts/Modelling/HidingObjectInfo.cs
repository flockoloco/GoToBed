using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingObjectInfo : ObjectInfoBase
{
    [SerializeField]
    Transform _entryPosition;
    [SerializeField]
    Transform _hiddenPosition;
    [SerializeField]
    Animator _objectAnimator;
    
    public Transform EntryPosition { get => _entryPosition; set => _entryPosition = value; }
    public Transform HiddenPosition { get => _hiddenPosition; set => _hiddenPosition = value; }
    public Animator ObjectAnimator { get => _objectAnimator; set => _objectAnimator = value; }
}
