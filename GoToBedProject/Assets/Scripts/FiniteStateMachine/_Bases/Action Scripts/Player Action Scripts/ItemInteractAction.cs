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
        if(!playerStats.EquippedItem.Equals(null) && playerStats.ItemPickUpAnimationBool.Equals(false))
        {
            Debug.Log("HELLO");
            //lerp animation

            Debug.Log(playerStats.EquippedItem.gameObject.transform.tag);
            playerStats.EquippedItem.transform.position = Vector3.Lerp(playerStats.EquippedItem.gameObject.transform.position,playerStats.HandPosition.position, 20 * Time.deltaTime);

            if (playerStats.EquippedItem.transform.position.Equals(playerStats.HandPosition.position))
            {

                playerStats.EquippedItem.transform.parent = playerStats.HandPosition.transform;
                playerStats.ItemPickUpAnimationBool = true;
            }
        
        
        
        }


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
                //mesma cena de detection, all interactables other than hiding
            }
            else if(Input.GetKeyUp(KeyCode.G))
            {
                //drop item animation
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