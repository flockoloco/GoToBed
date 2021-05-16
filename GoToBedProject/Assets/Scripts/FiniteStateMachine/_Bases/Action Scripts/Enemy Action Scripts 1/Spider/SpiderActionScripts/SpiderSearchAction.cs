using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Spider/Search Action")]
public class SpiderSearchAction : Action
{
    [SerializeField]
    float animationTimer = 0;
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        if (enemyStats.IsAtDestination())  
        {
            Debug.Log("aaaaaaaa my current waypoint is " + enemyStats.CurrentWaypoint);
           
            if (animationTimer.Equals(0))
            {
                Debug.Log("should be playing");
                enemyStats.Agent.isStopped = true;
                
                enemyStats.Animator.Play("Base Layer.enemyLookAround");
                animationTimer += Time.deltaTime;
            }
            else if (animationTimer < 2f) 
            {
                animationTimer += Time.deltaTime;
            }
            else if ( animationTimer > 2f) //change value to animation length
            {
                Debug.Log(" bbbbbbbbbbbb my current waypoint is " + enemyStats.CurrentWaypoint);
                enemyStats.SearchWaypoints.Remove(enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint]);
                enemyStats.GoToNextWaypoint(enemyStats.SearchWaypoints);
                Debug.Log(" ccccccccccc my current waypoint is " + enemyStats.CurrentWaypoint);
                animationTimer = 0;
                enemyStats.Agent.isStopped = false;
                enemyStats.Animator.Play("Base Layer.enemyWalk");
            }
            
        }

    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
