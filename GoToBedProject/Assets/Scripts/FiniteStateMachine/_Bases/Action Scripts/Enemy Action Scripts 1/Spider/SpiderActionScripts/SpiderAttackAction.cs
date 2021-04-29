using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Spider/Attack Action")]
public class SpiderAttackAction : Action
{
    [SerializeField]
    float deathTimer = 0;
    [SerializeField]
    private State deadState;
    Vector3 deathOffSet = new Vector3(0, 0, 3);
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        enemyStats.Target.transform.LookAt(fsm.transform.position, Vector3.up); //mudar 

        deathTimer += Time.deltaTime;
        if (deathTimer == 0f)
        {
        }
        else if (deathTimer >= 0.5f && deathTimer <= 2f)
        {
            enemyStats.Target.GetComponent<FiniteStateMachine>().CurrentState = deadState;

            
        }
        else if (deathTimer >= 2f && deathTimer <= 3f)
        {
            fsm.GetAgent().StopAgent();
            //wait a minute soldier
        }
        else if (deathTimer > 3f)
        {
            //omegalul
            deathTimer = 0;
        }
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
