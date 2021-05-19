using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Enemy Has Nothing To Search")]
public class EnemyNothingToSearchCondition : Condition
{
    [SerializeField]
    SpiderSearchAction _spiderSearchAction;
    //[SerializeField]
    //crookedsearchAction
    [SerializeField]
    private bool negation;
    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override bool Test(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
       if (enemyStats.CurrentWaypoint >= enemyStats.SearchWaypoints.Count - 1)
        {
        //fix isso aqui
           // if(_crookedSearch == null)
            //{
                if (_spiderSearchAction.finishedLastWaypoint)
                {
                    return !negation;
                }
           // }
           /* else
            {
                if (_crookedSearch.finishedLastWaypoint)
                {
                    return !negation;
                }
            }*/
        }
        return negation;
    }

    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
