using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Spider/Attack Action")]
public class SpiderAttackAction : Action
{
    [SerializeField]
    private State deadState;
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
       
            Vector3 dir = (enemyStats.transform.position - enemyStats.Target.transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.gameObject.transform.rotation = Quaternion.Slerp(enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.gameObject.transform.rotation, targetRotation, Time.deltaTime * 8f);

            enemyStats.transform.LookAt(enemyStats.Target.transform);
            
        
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
