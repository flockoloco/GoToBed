using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Clown/FreezeExitAction")]
public class clownexitFreezeAction : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        enemyStats.Animator.SetFloat(enemyStats.Animator.GetParameter(6).name, 1);
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
