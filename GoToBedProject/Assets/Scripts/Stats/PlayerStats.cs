using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class PlayerStats : Stats
{
    private float _staminaValue;
    private float _concealmentValue;
    private float _noiseValue;

    public float ConcealmentValue { get => _concealmentValue; set => _concealmentValue = value; }
    public float StaminaValue { get => _staminaValue; set => _staminaValue = value; }
    public float NoiseValue { get => _noiseValue; set => _noiseValue = value; }
    
}
