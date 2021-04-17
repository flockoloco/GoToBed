using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public abstract void Act(FiniteStateMachine fsm, PlayerStats playerStats);
    public abstract void Act(FiniteStateMachine fsm, EnemyStats enemyStats);
    public abstract void Act(FiniteStateMachine fsm, PlayerStats playerStats ,EnemyStats[] allEnemyStats); //if this isnt needed change Condition.cs , Transition.cs and this
}
