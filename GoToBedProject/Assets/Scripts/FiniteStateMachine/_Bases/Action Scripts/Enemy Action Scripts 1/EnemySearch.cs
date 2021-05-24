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
                    enemyStats.TurnOffThenTurnOnAnimation("LookingAround");
                }
                else if (enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].type.Equals(1))
                {

                    enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].transform.parent.GetComponent<HidingObjectInfo>().ObjectAnimator.Play(0);
                    enemyStats.TurnOffThenTurnOnAnimation("LookingInside");
                    if (enemyStats.Target.GetComponent<PlayerStats>().InsideHidingObject == true &&
                        enemyStats.Target.GetComponent<PlayerStats>().InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.position == enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].wpPosition)
                    {
                        animationTimer = 0;
                        Debug.Log("you dead yet?  hello ");
                        enemyStats.Target.GetComponent<PlayerStats>().PlayerDead = true;
                        enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.CameraState = 3;
                        enemyStats.StopAgent();
                        enemyStats.Agent.isStopped = true;
                        enemyStats.TurnOffThenTurnOnAnimation("Attacking");
                        enemyStats.transform.LookAt(enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.transform);
                        fsm.CurrentState = attackState;
                    }
                }
                else if (enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].type.Equals(2))
                {
                    enemyStats.TurnOffThenTurnOnAnimation("LookingUnder");
                   
                    if (enemyStats.Target.GetComponent<PlayerStats>().InsideHidingObject == true &&
                       enemyStats.Target.GetComponent<PlayerStats>().InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.position == enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].wpPosition)
                    {
                        animationTimer = 0;
                        Debug.Log("you dead yet?  hello ");
                        enemyStats.Target.GetComponent<PlayerStats>().PlayerDead = true;
                        enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.CameraState = 3;
                        enemyStats.StopAgent();
                        enemyStats.Agent.isStopped = true;
                        enemyStats.TurnOffThenTurnOnAnimation("Attacking");
                        enemyStats.transform.LookAt(enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.transform);
                        fsm.CurrentState = attackState;
                    }
                }
                else if (enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].type.Equals(3))
                {
                    enemyStats.TurnOffThenTurnOnAnimation("LookingUnder");
                    Debug.Log("I WAS HERE");
                    if (enemyStats.Target.GetComponent<PlayerStats>().InsideHidingObject == true &&
                       enemyStats.Target.GetComponent<PlayerStats>().InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.position == enemyStats.SearchWaypoints[enemyStats.CurrentWaypoint].wpPosition)
                    {
                        animationTimer = 0;
                        Debug.Log("you dead yet?  hello ");
                        enemyStats.Target.GetComponent<PlayerStats>().PlayerDead = true;
                        enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.CameraState = 3;
                        enemyStats.StopAgent();
                        enemyStats.Agent.isStopped = true;
                        enemyStats.TurnOffThenTurnOnAnimation("Attacking");
                        enemyStats.transform.LookAt(enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.transform);
                        fsm.CurrentState = attackState;
                    }   
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
                enemyStats.TurnOffThenTurnOnAnimation("Walking");

            }
            
        }

    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
