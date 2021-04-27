using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Spider/Attack Action")]
public class SpiderAttackAction : Action
{
    private float deathTimer;
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        Vector3 deathOffSet = new Vector3(0, 0, 3);
        deathTimer = 0;
        deathTimer++;
        enemyStats.Target.gameObject.transform.position = Vector3.Lerp(enemyStats.Target.gameObject.transform.position, enemyStats.gameObject.transform.position + deathOffSet, 8 * Time.deltaTime);
        enemyStats.Target.gameObject.transform.rotation = Quaternion.Lerp(enemyStats.Target.gameObject.transform.rotation, enemyStats.gameObject.transform.rotation, 8 * Time.deltaTime);
        if (deathTimer > 3f)
        {
            Destroy(enemyStats.Target.gameObject);
        }
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
