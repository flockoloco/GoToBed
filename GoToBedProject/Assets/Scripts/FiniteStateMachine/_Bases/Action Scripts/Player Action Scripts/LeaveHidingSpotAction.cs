using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Exit Hiding")]
public class LeaveHidingSpotAction : Action
{
    [SerializeField]
    PlayerHidingAction _hidingAction;
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        
        HidingObjectInfo hidingObject = playerStats.InteractingObject.GetComponent<HidingObjectInfo>();
        _hidingAction.timer = 0;
        playerStats.transform.position = hidingObject.EntryPosition.transform.position;
        playerStats.transform.rotation = hidingObject.HiddenPosition.transform.rotation;
        playerStats.InsideHidingObject = false;
        
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
