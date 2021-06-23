using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Raycast Interactable Action")]
public class RaycastInteractableAction : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        RaycastHit hit;
        if (Physics.Raycast(playerStats.PlayerCamera.gameObject.transform.position, playerStats.PlayerCamera.gameObject.transform.forward,out hit, playerStats.InteractRange,LayerMask.GetMask("Interactable","DoorLayer","LevelCollider")))
        {
            if (hit.collider.CompareTag(Globals.GameTags.Interactable.ToString()))
            {
               /* RaycastHit secondHitCheck;
                if ( !Physics.Raycast(playerStats.PlayerCamera.gameObject.transform.position, playerStats.PlayerCamera.gameObject.transform.forward, out secondHitCheck, playerStats.InteractRange, LayerMask.GetMask("LevelCollider"))||
                    (Vector3.Distance(playerStats.transform.position, secondHitCheck.point) > Vector3.Distance(playerStats.transform.position, hit.point)))
                { */
                
                    //add canvas thing saying "Interact"
                if (FindParentWithTag(hit.collider.gameObject, Globals.GameTags.Closet.ToString(), playerStats) != null)
                {
                    playerStats.LookingAtInteractable = Globals.InteractingObjects.Hiding;
                }
                else if (FindParentWithTag(hit.collider.gameObject, Globals.GameTags.Table.ToString(), playerStats) != null)
                {
                    playerStats.LookingAtInteractable = Globals.InteractingObjects.Hiding;
                }
                else if (FindParentWithTag(hit.collider.gameObject, Globals.GameTags.Lantern.ToString(), playerStats) != null)
                {
                    playerStats.LookingAtInteractable = Globals.InteractingObjects.Item;
                }
                else if (FindParentWithTag(hit.collider.gameObject, Globals.GameTags.Scissors.ToString(), playerStats) != null)
                {
                    playerStats.LookingAtInteractable = Globals.InteractingObjects.Item;
                }
                else if (FindParentWithTag(hit.collider.gameObject, Globals.GameTags.Bed.ToString(), playerStats) != null)
                {
                    playerStats.LookingAtInteractable = Globals.InteractingObjects.Hiding;
                }
                else if (FindParentWithTag(hit.collider.gameObject, Globals.GameTags.Web.ToString(), playerStats) != null)
                {
                    playerStats.LookingAtInteractable = Globals.InteractingObjects.Objective;
                }
                else if (FindParentWithTag(hit.collider.gameObject, Globals.GameTags.Door.ToString(), playerStats) != null)
                {
                    playerStats.LookingAtInteractable = Globals.InteractingObjects.Door;
                }
                else if (FindParentWithTag(hit.collider.gameObject, Globals.GameTags.Key.ToString(), playerStats) != null)
                {
                    playerStats.LookingAtInteractable = Globals.InteractingObjects.Item;
                }
                else if (FindParentWithTag(hit.collider.gameObject, Globals.GameTags.DarkZone.ToString(), playerStats) != null)
                {
                    playerStats.LookingAtInteractable = Globals.InteractingObjects.Objective;
                }
                else if (FindParentWithTag(hit.collider.gameObject, Globals.GameTags.TeddyBear.ToString(), playerStats) != null)
                {
                    playerStats.LookingAtInteractable = Globals.InteractingObjects.Item;
                }
                else if (FindParentWithTag(hit.collider.gameObject, Globals.GameTags.NoLightFlashLight.ToString(), playerStats) != null)
                {
                    playerStats.LookingAtInteractable = Globals.InteractingObjects.Objective;
                }
                else if (FindParentWithTag(hit.collider.gameObject, Globals.GameTags.Battery.ToString(), playerStats) != null)
                {
                    playerStats.LookingAtInteractable = Globals.InteractingObjects.Item;
                }

                //}
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
        else
        {
            playerStats.InteractingObject = null;
            playerStats.LookingAtInteractable = Globals.InteractingObjects.None;
        }
        AddInteractText(playerStats);
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
        if (childObject.CompareTag(tag))
        {
            return childObject;
        }

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
    private void AddInteractText(PlayerStats playerStats)
    {
        if (playerStats.LookingAtInteractable.Equals(Globals.InteractingObjects.Hiding))
        {
            playerStats.UIInteractionTextObject.gameObject.SetActive(true);
            
                playerStats.UIInteractionTextObject.ChangeText("Hide!");
            
           
        }
        else if (playerStats.LookingAtInteractable.Equals(Globals.InteractingObjects.Item))
        {
            if (!playerStats.EquippedItem)
            {
                playerStats.UIInteractionTextObject.gameObject.SetActive(true);
                playerStats.UIInteractionTextObject.ChangeText("Pick Up!");
            }
            else
            {
                playerStats.UIInteractionTextObject.gameObject.SetActive(true);
                playerStats.UIInteractionTextObject.ChangeText("Drop & Pick!");
            }
        }
        else if (playerStats.LookingAtInteractable.Equals(Globals.InteractingObjects.Objective))
        {
            playerStats.UIInteractionTextObject.gameObject.SetActive(true);
            if (playerStats.EquippedItem)
            {

                if (playerStats.EquippedItem.CompareTag(playerStats.InteractingObject.GetComponent<objectiveobjectinfo>().UsableTag.ToString()))
                {
                    playerStats.UIInteractionTextObject.ChangeText(playerStats.InteractingObject.GetComponent<objectiveobjectinfo>().CorrectItemText);
                }
                else
                {
                    playerStats.UIInteractionTextObject.ChangeText(playerStats.InteractingObject.GetComponent<objectiveobjectinfo>().WrongItemText);
                }
            }
            else
            {
                playerStats.UIInteractionTextObject.ChangeText(playerStats.InteractingObject.GetComponent<objectiveobjectinfo>().WrongItemText);
            }


        }
        else if (playerStats.LookingAtInteractable.Equals(Globals.InteractingObjects.Door))
        {
            playerStats.UIInteractionTextObject.gameObject.SetActive(true);
            if (playerStats.InteractingObject.GetComponent<DoorScript>().Locked)
            {
                if (playerStats.EquippedItem)
                {
                    
                    if (playerStats.EquippedItem.CompareTag(playerStats.InteractingObject.GetComponent<DoorScript>().UsableTag.ToString()))
                    {
                        playerStats.UIInteractionTextObject.ChangeText(playerStats.InteractingObject.GetComponent<DoorScript>().UnlockText);
                    }
                    else
                    {
                        playerStats.UIInteractionTextObject.ChangeText(playerStats.InteractingObject.GetComponent<DoorScript>().WrongItemText);
                    }
                }
                else
                {
                    playerStats.UIInteractionTextObject.ChangeText(playerStats.InteractingObject.GetComponent<DoorScript>().WrongItemText);
                }
                   
            }
            else if (playerStats.InteractingObject.GetComponent<DoorScript>().Open)
            {
                playerStats.UIInteractionTextObject.ChangeText(playerStats.InteractingObject.GetComponent<DoorScript>().CloseText);
            }
            else
            {
                playerStats.UIInteractionTextObject.ChangeText(playerStats.InteractingObject.GetComponent<DoorScript>().CorrectItemText);
            }
        }
        else if (playerStats.LookingAtInteractable.Equals(Globals.InteractingObjects.None))
        {
            playerStats.UIInteractionTextObject.ChangeText(false);
        }
    }
}
