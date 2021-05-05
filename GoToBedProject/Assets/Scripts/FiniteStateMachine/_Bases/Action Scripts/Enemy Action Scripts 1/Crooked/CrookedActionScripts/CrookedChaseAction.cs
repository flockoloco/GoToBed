using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Crooked/Chase Action")]
public class CrookedChaseAction : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        if (enemyStats.IsAtDestination())
        {
            enemyStats.GoToTarget();
        }
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
