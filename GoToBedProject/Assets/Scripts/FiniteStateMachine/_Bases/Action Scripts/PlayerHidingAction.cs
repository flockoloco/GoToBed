using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Hiding")]
public class PlayerHidingAction : Action
{
    public float timer = 0;

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        if (!playerStats.InsideHidingObject)
        {
            
            if (timer == 0f)
            {
                //playerStats.transform.position = playerStats.InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.position; // instead of this do a fast transform, not a blink
                //playerStats.transform.rotation = playerStats.InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.rotation;
            }
            else if ( timer < 0.5f)
            {
                playerStats.gameObject.transform.position = Vector3.Lerp(playerStats.gameObject.transform.position, playerStats.InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.position, 15f * Time.deltaTime);
                playerStats.gameObject.transform.rotation = Quaternion.Lerp(playerStats.gameObject.transform.rotation, playerStats.InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.rotation, 15f * Time.deltaTime);
               
            }else if (timer > 0.5f && timer < 1f)
            {

            }
            else if (timer > 1f && timer < 2f)
            {
                playerStats.gameObject.transform.position = Vector3.Lerp(playerStats.gameObject.transform.position, playerStats.InteractingObject.GetComponent<HidingObjectInfo>().HiddenPosition.position, 8 * Time.deltaTime);
                playerStats.gameObject.transform.rotation = Quaternion.Lerp(playerStats.gameObject.transform.rotation, playerStats.InteractingObject.GetComponent<HidingObjectInfo>().HiddenPosition.rotation, 8* Time.deltaTime);
                playerStats.ConcealmentValue = 0.5f; //change into a decreasing function
            } 
            timer += Time.deltaTime;
            if (timer > 2f)
            {
                playerStats.InsideHidingObject = true;
                timer = 0;
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
}