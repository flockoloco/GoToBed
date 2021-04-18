using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Crouch Entry Action")]
public class CrouchEntryAction : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        Debug.Log("Entering crouch");
        Vector3 initialFeetPosition = playerStats.GroundCheck.position;
        playerStats.gameObject.transform.localScale = playerStats.gameObject.transform.localScale / 2;
        Vector3 postFeetPosition = playerStats.GroundCheck.position;
        playerStats.gameObject.transform.position -= (postFeetPosition - initialFeetPosition) * 0.9f;
        playerStats.MoveSpeed = playerStats.MoveSpeed / 2;
        //change animation ou wtv
        
        
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
