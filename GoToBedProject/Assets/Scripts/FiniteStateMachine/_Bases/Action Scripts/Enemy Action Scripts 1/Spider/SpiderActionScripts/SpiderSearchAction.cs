using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Spider/Search Action")]
public class SpiderSearchAction : Action
{
    [SerializeField]
    private State attackState;
    public float animationTimer = 0;
    public bool finishedLastWaypoint;
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        Debug.DrawLine(enemyStats.transform.position, enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].wpPosition,Color.red);
        if (enemyStats.IsAtDestination())  
        {
            finishedLastWaypoint = false;

           
            if (animationTimer.Equals(0))
            {

              
                enemyStats.Agent.isStopped = true;
                if (enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].type.Equals(0))
                {
                    enemyStats.Animator.Play("Base Layer.enemyLookAround");
                }
                else if (enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].type.Equals(1))
                {
                    enemyStats.Animator.Play("Base Layer.enemyLookInCloset");
                    if (enemyStats.Target.GetComponent<PlayerStats>().InsideHidingObject == true &&
                        enemyStats.Target.GetComponent<PlayerStats>().InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.position == enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].wpPosition)
                    {
                        fsm.CurrentState = attackState;
                    }
                }
                else if (enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].type.Equals(2))
                {
                    enemyStats.Animator.Play("Base Layer.enemyLookUnderObject");
                }
                else if (enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].type.Equals(3))
                {
                    enemyStats.Animator.Play("Base Layer.enemyLookUnderObject");
                }
                animationTimer += Time.deltaTime;
            }
            else if (animationTimer < 2f) 
            {
                animationTimer += Time.deltaTime;
            }
            else if ( animationTimer > 2f) //change value to animation length
            {  
                
                if (enemyStats.CurrentWaypoint >= enemyStats.SearchWaypoints.Count - 1)    
                {
                    Debug.Log("YOYOYOYOYOOY");
                    finishedLastWaypoint = true; //cringeira POG
                }
                else
                { 
                    enemyStats.GoToNextWaypoint(enemyStats.SearchWaypoints);
                }
                
                
             
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
