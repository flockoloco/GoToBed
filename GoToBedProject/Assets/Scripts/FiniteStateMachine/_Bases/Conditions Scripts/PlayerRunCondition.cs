using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                Debug.Log("leaving run state");
                return !negation;
            }
            else if (playerStats.StaminaObject.GetComponent<Image>().fillAmount <= 0.001f)
            {
                return !negation;
            }
            else if (! ( Input.GetAxis("Vertical") > 0))
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
            if (playerStats.StaminaObject.GetComponent<Image>().fillAmount > 0.5f)
            {
                if (Input.GetAxis("Vertical") > 0)
                {
                    Debug.Log("entering run state");
                    return !negation;
                }
               
            } 
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