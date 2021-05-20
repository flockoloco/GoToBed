using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Entry Chase")]
public class EnemyChaseEntry : Action
{
    [SerializeField]
    private bool exit;
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        if (!exit)
        {
            if (enemyStats.EnemyName == Globals.Enemy.CrookedMan)
            {
                enemyStats.MoveSpeed = 8;
            }
        }
        else
        {
            enemyStats.MoveSpeed = 4;
        }

        //Chase ANIMATION here
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
