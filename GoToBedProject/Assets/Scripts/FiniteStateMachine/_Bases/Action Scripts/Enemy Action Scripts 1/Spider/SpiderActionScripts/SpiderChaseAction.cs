using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Spider/Chase Action")]
public class SpiderChaseAction : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        if (fsm.GetAgent().IsAtDestination())
        {
            fsm.GetAgent().GoToTarget();
            //animation
        }
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
