using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Item Interaction Action")]
public class ItemInteractAction : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        //seperate set of ifs for animations
        //run timer here inside of ifs
        


        if (playerStats.EquippedItem.Equals(null) && playerStats.InsideHidingObject.Equals(false))
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (playerStats.InteractionCoolDown > playerStats.InteractionCooldownValue)
                {
                    if (playerStats.LookingAtInteractable.Equals(Globals.InteractingObjects.Item)) //detect what ur interacting with
                                                                                                    //make ifs for diferent interactables (not hiding)
                    {   
                        playerStats.InteractionCoolDown = 0;
                        playerStats.EquippedItem = playerStats.InteractingObject;
                        playerStats.ItemPickUpAnimationBool = false;
                        
                    }
                }
            }
        }
        else if (!playerStats.EquippedItem.Equals(null) && playerStats.InsideHidingObject.Equals(false))
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (playerStats.InteractionCoolDown > playerStats.InteractionCooldownValue)
                {
                    if (playerStats.LookingAtInteractable.Equals(Globals.InteractingObjects.Item)) //detect what ur interacting with
                                                                                                   //make ifs for diferent interactables (not hiding)
                    {
                        //drop item and grab the other

                        playerStats.InteractionCoolDown = 0;
                        playerStats.EquippedItem.transform.parent = null;
                        playerStats.EquippedItem.GetComponent<ItemInfoScript>().ChangeCollidableLayer(8);
                        Debug.Log(playerStats.EquippedItem.layer + "this the layer");
                        playerStats.EquippedItem.transform.position = playerStats.InteractingObject.transform.position;


                        playerStats.EquippedItem = playerStats.InteractingObject;


                        playerStats.EquippedItem = playerStats.InteractingObject;
                        playerStats.EquippedItem.GetComponent<ItemInfoScript>().ChangeCollidableLayer(0);
                        playerStats.ItemPickUpAnimationBool = false;





                    }
                    if (playerStats.LookingAtInteractable.Equals(Globals.InteractingObjects.Objective))
                    {
                        if (playerStats.EquippedItem.CompareTag(playerStats.InteractingObject.GetComponent<objectiveobjectinfo>().UsableTag.ToString())){
                            playerStats.InteractingObject.GetComponent<objectiveobjectinfo>().ObjectiveInteraction(playerStats);
                        }
                    }
                }
            }
        }
        if (!playerStats.EquippedItem.Equals(null) && playerStats.ItemPickUpAnimationBool.Equals(false))
        {
            //lerp animation
            playerStats.EquippedItem.GetComponent<ItemInfoScript>().ChangeCollidableLayer(0);

            playerStats.EquippedItem.transform.position = Vector3.Lerp(playerStats.EquippedItem.gameObject.transform.position, playerStats.HandPosition.position, 20 * Time.deltaTime);
            Debug.Log(Vector3.Distance(playerStats.EquippedItem.transform.position, playerStats.HandPosition.transform.position));
            if (Vector3.Distance(playerStats.EquippedItem.transform.position, playerStats.HandPosition.transform.position) < 0.5f)
            {
                playerStats.EquippedItem.transform.position = playerStats.HandPosition.transform.position;
                playerStats.EquippedItem.transform.rotation = playerStats.HandPosition.transform.rotation;
            }


            if (playerStats.EquippedItem.transform.position.Equals(playerStats.HandPosition.position))
            {
                Debug.Log("end of animation");
                playerStats.EquippedItem.transform.parent = playerStats.HandPosition.transform;

                playerStats.ItemPickUpAnimationBool = true;
            }



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
    private void EquipNewItem()
    {

    }
}