using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Spider/Search Action")]
public class SpiderSearchAction : Action
{
    float animationTimer = 0;
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        if (enemyStats.IsAtDestination())
        {
            animationTimer += Time.deltaTime;
            if (animationTimer < 2.5f)
            {
                // do animation or GIRO
            }
            else
            {
                enemyStats.currentList = "Searching List";
                enemyStats.GoToNextWaypoint(enemyStats.SearchWaypoints);
                enemyStats.SearchWaypoints.Remove(enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint]);
            }
        }
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
