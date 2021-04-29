using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Spider/Attack Action")]
public class SpiderAttackAction : Action
{
    [SerializeField]
    float deathTimer = 0;
    Vector3 deathOffSet = new Vector3(0, 0, 3);
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        deathTimer += Time.deltaTime;
        Debug.Log(deathTimer);
        if (deathTimer == 0f)
        {
        }
        else if (deathTimer >= 0.5f && deathTimer <= 2f)
        {
            
            enemyStats.Target.gameObject.transform.position = Vector3.Lerp(enemyStats.Target.gameObject.transform.position, enemyStats.gameObject.transform.position + deathOffSet, 8 * Time.deltaTime);
         //Como está o player morre olhando para o inimigo, se quiser fazer ao contrario e aos mãos indo em direcao aos olhos podemos só tirar o quaternion inverse
            enemyStats.Target.gameObject.transform.rotation = Quaternion.Lerp(enemyStats.Target.gameObject.transform.rotation, (enemyStats.gameObject.transform.rotation), 8 * Time.deltaTime);
            
        }
        else if (deathTimer >= 2f && deathTimer <= 3f)
        {
            fsm.GetAgent().StopAgent();
            //wait a minute soldier
        }
        else if (deathTimer > 3f)
        {
            Destroy(enemyStats.Target.gameObject);
            //omegalul
            deathTimer = 0;
        }
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
