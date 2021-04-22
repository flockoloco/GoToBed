using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Player Run Condition")]
public class PlayerRunCondition : Condition
{
    [SerializeField]
    private bool negation;
    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        if (fsm.CurrentState.name == "Run")
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                return !negation;
            }
            else
            {
                return negation;
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift))
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