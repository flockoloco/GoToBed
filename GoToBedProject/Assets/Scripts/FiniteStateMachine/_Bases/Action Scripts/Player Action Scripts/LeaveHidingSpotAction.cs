using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Exit Hiding")]
public class LeaveHidingSpotAction : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        
        HidingObjectInfo hidingObject = playerStats.InteractingObject.GetComponent<HidingObjectInfo>();
        
        playerStats.gameObject.transform.position = hidingObject.EntryPosition.transform.position;
        Debug.Log(playerStats.transform.position);
        Debug.Log(hidingObject.EntryPosition.transform.position);
        playerStats.gameObject.transform.rotation = hidingObject.HiddenPosition.transform.rotation;
        playerStats.InsideHidingObject = false;
        Debug.Log(hidingObject);
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        fsm.GetAgent().StopAgent();
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
