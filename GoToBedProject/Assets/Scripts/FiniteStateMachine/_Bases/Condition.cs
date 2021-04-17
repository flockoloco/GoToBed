using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Condition : ScriptableObject
{
    public abstract bool Test(FiniteStateMachine fsm, PlayerStats playerStats);
    public abstract bool Test(FiniteStateMachine fsm, EnemyStats enemyStats);
    public abstract bool Test(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats);
}
