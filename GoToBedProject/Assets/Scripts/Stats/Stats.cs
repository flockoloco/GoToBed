using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _gravity;
    [SerializeField]
    private FiniteStateMachine _fSM;

    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public FiniteStateMachine FSM { get => _fSM; set => _fSM = value; }
    public float Gravity { get => _gravity; set => _gravity = value; }
}

