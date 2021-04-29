using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/transition")]
public class Transition : ScriptableObject
{
    [SerializeField]
    private Condition decision;
    [SerializeField]
    private Action action;
    [SerializeField]
    private State targetState;


    public bool IsTriggered(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        return decision.Test(fsm, playerStats);
    }
    public bool IsTriggered(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        return decision.Test(fsm, enemyStats);
    }
    public bool IsTriggered(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        return decision.Test(fsm, playerStats ,allEnemyStats);
    }
    public State GetTargetState()
    {
        return targetState;
    }
    public Action GetAction()
    {
        return action;
    }

}