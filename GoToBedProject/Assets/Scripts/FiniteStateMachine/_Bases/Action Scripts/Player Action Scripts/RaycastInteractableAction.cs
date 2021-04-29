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
            if (hit.collider.CompareTag(Globals.GameTags.Interactable.ToString()))
            {
                //add canvas thing saying "Interact"
                if (FindParentWithTag(hit.collider.gameObject, Globals.GameTags.Closet.ToString(),playerStats) != null)
                {
                    playerStats.LookingAtInteractable = Globals.InteractingObjects.Hiding;
                    //add ui
                }
                else if (FindParentWithTag(hit.collider.gameObject, Globals.GameTags.Lantern.ToString(),playerStats) != null)
                {
                    playerStats.LookingAtInteractable = Globals.InteractingObjects.Item;
                    //add ui
                }
                else if (FindParentWithTag(hit.collider.gameObject, Globals.GameTags.Bed.ToString(), playerStats) != null)
                {
                    playerStats.LookingAtInteractable = Globals.InteractingObjects.Hiding;
                    //add ui
                }
            }
            else
            {
                playerStats.InteractingObject = null;
                playerStats.LookingAtInteractable = Globals.InteractingObjects.None;
            }
        }
        else
        {
            playerStats.InteractingObject = null;
            playerStats.LookingAtInteractable = Globals.InteractingObjects.None;
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
    private GameObject FindParentWithTag(GameObject childObject, string tag,PlayerStats playerStats) //method gotten from a forum
    {
        Transform t = childObject.transform;
        while (t.parent != null)
        {
            if (t.parent.CompareTag(tag))
            { 
                playerStats.InteractingObject = t.parent.gameObject;
                return t.parent.gameObject;
            }
            t = t.parent.transform;
        }
        return null; // Could not find a parent with given tag.
    }
}
