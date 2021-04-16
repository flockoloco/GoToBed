using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerStats : Stats
{
    private float _staminaValue;
    private float _concealmentValue;
    private float _noiseValue;

    [SerializeField]
    private CharacterController _playerController;
    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private float _groundDistance = 0.3f;
    [SerializeField]
    private LayerMask _groundmask;


    public float ConcealmentValue { get => _concealmentValue; set => _concealmentValue = value; }
    public float StaminaValue { get => _staminaValue; set => _staminaValue = value; }
    public float NoiseValue { get => _noiseValue; set => _noiseValue = value; }
    public float GroundDistance { get => _groundDistance; set => _groundDistance = value; }
    public LayerMask Groundmask { get => _groundmask; set => _groundmask = value; }
    public Transform GroundCheck { get => _groundCheck; set => _groundCheck = value; }
    public CharacterController PlayerController { get => _playerController; set => _playerController = value; }
}
