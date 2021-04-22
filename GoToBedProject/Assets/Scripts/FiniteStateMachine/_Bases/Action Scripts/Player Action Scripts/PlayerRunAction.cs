using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Run Action")]
public class PlayerRunAction : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        if (playerStats.StaminaBar > 0)
        {
            playerStats.StaminaBar -= 0.2f;
        }
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
