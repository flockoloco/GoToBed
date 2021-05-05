using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{
    public enum objectType
    {
        floor,
        wall
    }
    public objectType Type;
    public int soundReduction;
    public int soundMovement;

}
