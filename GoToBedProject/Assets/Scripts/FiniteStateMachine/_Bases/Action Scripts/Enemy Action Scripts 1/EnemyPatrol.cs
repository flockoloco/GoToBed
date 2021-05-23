using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Patrol")]
public class EnemyPatrol : Action
{
    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        enemyStats.TurnOffThenTurnOnAnimation("Walking");
        if (enemyStats.IsAtDestination())
        {
            enemyStats.GoToNextWaypoint(enemyStats.DefaultWaypoints);
        }
    }
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}