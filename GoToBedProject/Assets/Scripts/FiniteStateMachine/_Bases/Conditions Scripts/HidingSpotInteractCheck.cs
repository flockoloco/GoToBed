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
            if (playerStats.InsideHidingObject == false && playerStats.InteractionCoolDown > playerStats.InteractionCooldownValue)
            {
                if (playerStats.LookingAtInteractable == true)
                {
                    //add ifs for different objects that need different animations?
                    if (playerStats.InteractingObject.name == "closet")//maybe change? maybe create multiple tags system https://answers.unity.com/questions/1470694/multiple-tags-for-one-gameobject.html
                    {
                        playerStats.InteractionCoolDown = 0;
                        return !negation;
                    }
                }
            }
            else if (playerStats.InsideHidingObject == true)
            {
                if (playerStats.InteractingObject.name == "closet")//maybe change? maybe create multiple tags system https://answers.unity.com/questions/1470694/multiple-tags-for-one-gameobject.html
                {
                    playerStats.InteractionCoolDown = 0;
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