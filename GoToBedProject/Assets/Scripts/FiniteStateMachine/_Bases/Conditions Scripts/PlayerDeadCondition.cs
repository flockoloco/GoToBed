using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Player Dead Condition")]
public class PlayerDeadCondition : Condition
{
    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        if (playerStats.PlayerDead.Equals(true))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override bool Test(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        throw new System.NotImplementedException();
    }

    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
