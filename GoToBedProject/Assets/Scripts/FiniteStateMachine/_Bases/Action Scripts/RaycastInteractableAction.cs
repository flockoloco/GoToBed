using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Raycast Interactable Action")]
public class RaycastInteractableAction : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
       RaycastHit hit;

        
        if (Physics.Raycast(playerStats.PlayerCamera.transform.position, playerStats.PlayerCamera.transform.forward,out hit, playerStats.InteractRange))
        {
            if (hit.collider.tag == "Interactable")
            {
                //add canvas thing saying "Interact"
                playerStats.InteractingObject = hit.collider.transform.parent.gameObject;
                playerStats.LookingAtInteractable = true;

            }
            else
            {
                playerStats.LookingAtInteractable = false;

            }
           //other ifs
        }
        else
        {
            playerStats.LookingAtInteractable = false;
        }
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
