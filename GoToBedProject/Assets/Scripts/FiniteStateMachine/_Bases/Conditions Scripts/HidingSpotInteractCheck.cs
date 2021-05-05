using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Hiding Spot Interaction Condition")]
public class HidingSpotInteractCheck : Condition
{
    [SerializeField]
    private bool negation;
    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (playerStats.InsideHidingObject.Equals(false) && playerStats.InteractionCoolDown > playerStats.InteractionCooldownValue)
            {
                if (playerStats.LookingAtInteractable.Equals(Globals.InteractingObjects.Hiding))
                {
                    
                        playerStats.InteractionCoolDown = 0;
                        Debug.Log("entering hiding state");
                        return !negation;
                    
                }
            }
            else if (playerStats.InsideHidingObject.Equals(true))
            {
                if (playerStats.LookingAtInteractable.Equals(Globals.InteractingObjects.Hiding))
                {
                    playerStats.InteractionCoolDown = 0;
                    Debug.Log("leaving hiding state");
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