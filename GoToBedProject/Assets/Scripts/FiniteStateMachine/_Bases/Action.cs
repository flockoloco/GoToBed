using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public abstract void Act(FiniteStateMachine fsm, PlayerStats playerStats);
    public abstract void Act(FiniteStateMachine fsm, EnemyStats enemyStats);
}
