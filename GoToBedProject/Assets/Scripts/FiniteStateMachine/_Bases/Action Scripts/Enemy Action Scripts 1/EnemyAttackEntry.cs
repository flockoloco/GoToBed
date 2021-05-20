using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Attack Entry")]
public class EnemyAttackEntry : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        Debug.Log("you dead yet?  hello ");
        enemyStats.Target.GetComponent<PlayerStats>().PlayerDead = true;


        enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.CameraState = 3;
        enemyStats.StopAgent();
        enemyStats.Agent.isStopped = true;
        enemyStats.Animator.enabled = false;
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
