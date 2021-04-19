using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Clown/Patrol Action")]
public class ClownPatrolAction : Action
{
    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        if (fsm.GetAgent().IsAtDestination())
        {
            Debug.Log("im not comming here");
            fsm.GetAgent().GoToNextWaypoint();
        }
    }
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        Debug.Log("im not comming here");
        throw new System.NotImplementedException();
    }
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}