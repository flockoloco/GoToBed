using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Run Entry Action")]
public class PlayerRunEntry : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        Debug.Log("Run Entry");
        Vector3 initialFeetPosition = playerStats.GroundCheck.position;
        //playerStats.gameObject.transform.localScale = new Vector3(1, 1.253025f, 1);
        Vector3 postFeetPosition = playerStats.GroundCheck.position;
        playerStats.gameObject.transform.position -= (postFeetPosition - initialFeetPosition) * 0.9f;
        playerStats.MoveSpeed = 9;
        playerStats.TurnOffThenTurnOnAnimation("Running");
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
