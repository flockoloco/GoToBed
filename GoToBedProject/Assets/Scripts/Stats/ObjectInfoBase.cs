using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfoBase : MonoBehaviour
{
    
}
public class ItemObjectiveObjectInfoBase: ObjectInfoBase
{
    [SerializeField]
    private GameObject _collidableChild;
    public GameObject CollidableChild { get => _collidableChild; set => _collidableChild = value; }
}