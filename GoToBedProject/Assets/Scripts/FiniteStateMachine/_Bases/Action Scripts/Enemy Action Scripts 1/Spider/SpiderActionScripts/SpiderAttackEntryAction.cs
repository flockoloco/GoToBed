using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Spider/Attack Entry Action")]
public class SpiderAttackEntryAction : Action
{
    [SerializeField]
    private State deadState;
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        enemyStats.Target.GetComponent<FiniteStateMachine>().CurrentState = deadState;
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
