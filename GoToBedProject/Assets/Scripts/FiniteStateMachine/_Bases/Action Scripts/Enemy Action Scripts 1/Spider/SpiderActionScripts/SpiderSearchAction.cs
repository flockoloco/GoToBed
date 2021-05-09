using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Spider/Search Action")]
public class SpiderSearchAction : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        if (enemyStats.IsAtDestination())
        {
            //Debug.Log(enemyStats.CurrentWaypoint);
            enemyStats.SearchWaypoints.Remove(enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint]);
            if (enemyStats.SearchWaypoints.Count != 0)
            {
                enemyStats.GoToNextWaypoint(enemyStats.SearchWaypoints);
            }
            enemyStats.currentList = "Searching List";
        }
        
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
