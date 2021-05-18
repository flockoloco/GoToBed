using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/ Door Interaction Animation Action")]
public class EnemyDoorAnimationAction : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        //ja ta a dar play da animacao q leva trigger dentro da condition
        //aqui vou fazer a tristesa de ter a transition feita a mao, tem de ser :C
        //que assim n da trigger a entry action dos outros states
        if (enemyStats.OldDoorScript.Open.Equals(true))
        {
            Debug.Log(enemyStats.OldState);
            if (enemyStats.OldState.StateDisplayName.Equals("Search"))
            {
                enemyStats.SearchWaypoints = enemyStats.OldSearchList;
                enemyStats.CurrentWaypoint = enemyStats.OldCurrentWaypoint;
                enemyStats.Agent.SetDestination(enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].wpPosition);
                fsm.CurrentState = enemyStats.OldState;
            }
            else if (enemyStats.OldState.StateDisplayName.Equals("Patrol"))
            {
                enemyStats.CurrentWaypoint = enemyStats.OldCurrentWaypoint;
                enemyStats.Agent.SetDestination(enemyStats.DefaultWaypoints[enemyStats.CurrentWaypoint].wpPosition);
                fsm.CurrentState = enemyStats.OldState;
            }
            else if (enemyStats.OldState.StateDisplayName.Equals("Chase"))
            {
                enemyStats.GoToTarget();
                fsm.CurrentState = enemyStats.OldState;
            }
            
            
            
            
        }

    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
