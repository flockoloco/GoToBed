using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Hiding Spot Final Condition")]
public class LeaveHiddingfinalcondition : Condition
{
    [SerializeField]
    bool negation;
    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        if (!playerStats.InsideHidingObject)
        {
            return !negation;
        }
        return negation;
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
