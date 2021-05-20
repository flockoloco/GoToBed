using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Attack Action")]
public class EnemyAttack : Action
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
            
            //fazer aqui mesmo a diferenciação com o enemystats.enemyname
            //animacao (cada inimigo tem o seu play.animation para matar o player)
            // fazer if(enemystats.enemyname == blabla) {animacao.play } blabla
            // ou duplicar essa action e apenas trocar o animacao.play para ser do enemy correto
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
