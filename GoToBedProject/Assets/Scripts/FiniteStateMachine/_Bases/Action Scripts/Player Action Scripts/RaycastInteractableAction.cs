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
                playerStats.InteractingObject = FindParentWithTag( hit.collider.gameObject, "Closet");
                playerStats.LookingAtInteractable = true;

            }
            else
            {
                playerStats.InteractingObject = null;
                playerStats.LookingAtInteractable = false;

            }
           //other ifs
        }
        else
        {
            playerStats.InteractingObject = null;
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
    private GameObject FindParentWithTag(GameObject childObject, string tag) //method gotten from a forum
    {
        Transform t = childObject.transform;
        while (t.parent != null)
        {
            if (t.parent.tag == tag)
            {
                return t.parent.gameObject;
            }
            t = t.parent.transform;
        }
        return null; // Could not find a parent with given tag.
    }
}
