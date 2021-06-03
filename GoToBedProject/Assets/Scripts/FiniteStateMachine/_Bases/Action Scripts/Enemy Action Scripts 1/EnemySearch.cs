using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Search")]
public class EnemySearch : Action
{
    [SerializeField]
    private State attackState;
    public float animationTimer = 0;
    public bool finishedLastWaypoint;
    public float animationClipTimer;

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

            animationClipTimer = enemyStats.Animator.GetCurrentAnimatorClipInfo(0)[0].clip.length; 
            if (animationTimer.Equals(0))
            {

              
                enemyStats.Agent.isStopped = true;
                if (enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].type.Equals(0))
                {
                    enemyStats.TurnOffThenTurnOnAnimation("LookingAround");
                }
                else if (enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].type.Equals(1))
                {

                    enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].transform.parent.GetComponent<HidingObjectInfo>().ObjectAnimator.Play(0);
                    enemyStats.TurnOffThenTurnOnAnimation("LookingInside");
                    TryToAttackThePlayer(fsm, enemyStats);
                }
                else if (enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].type.Equals(2))
                {
                    enemyStats.TurnOffThenTurnOnAnimation("LookingUnder");

                    TryToAttackThePlayer(fsm, enemyStats);
                }
                else if (enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].type.Equals(3))
                {
                    enemyStats.TurnOffThenTurnOnAnimation("LookingUnder");
                    Debug.Log("I WAS HERE");
                    TryToAttackThePlayer(fsm, enemyStats);
                }
                animationTimer += Time.deltaTime;
            }
            else if (animationTimer < animationClipTimer)
            {
                animationTimer += Time.deltaTime;
            }
            else if (animationTimer > animationClipTimer) //change value to animation length
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
                enemyStats.TurnOffThenTurnOnAnimation("Walking");

            }
            
        }

    }
    private void TryToAttackThePlayer(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        enemyStats.transform.LookAt(enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].transform.parent);
        if (enemyStats.Target.GetComponent<PlayerStats>().InsideHidingObject == true &&
                       enemyStats.Target.GetComponent<PlayerStats>().InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.position == enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].wpPosition)
        {
            animationTimer = 0;
            enemyStats.Target.GetComponent<PlayerStats>().PlayerDead = true;
            enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.CameraState = 3;
            enemyStats.StopAgent();
            enemyStats.Agent.isStopped = true;
            enemyStats.TurnOffThenTurnOnAnimation("Attacking");
            enemyStats.transform.LookAt(enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.transform);
            fsm.CurrentState = attackState;
        }
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
