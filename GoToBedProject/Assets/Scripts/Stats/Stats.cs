using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Stats
{
    private float _moveSpeed;
    private FiniteStateMachine _fSM;

    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public FiniteStateMachine FSM { get => _fSM; set => _fSM = value; }
}

