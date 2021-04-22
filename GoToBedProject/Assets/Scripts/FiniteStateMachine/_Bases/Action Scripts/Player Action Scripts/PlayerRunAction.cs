using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunAction : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        //stamina
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
