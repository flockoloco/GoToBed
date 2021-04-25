using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObjectInfo : MonoBehaviour
{
    //add more if needed
    [SerializeField]
    float _lightPotency;
    [SerializeField]
    float _lightRadius;

    public float LightPotency { get => _lightPotency; set => _lightPotency = value; }
    public float LightRadius { get => _lightRadius; set => _lightRadius = value; }
}
