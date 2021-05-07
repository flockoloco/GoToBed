using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Hiding")]
public class PlayerHidingAction : Action
{
    private float _timer = 0;

    public float Timer { get => _timer; set => _timer = value; }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        if (!playerStats.InsideHidingObject)
        {
            if (Timer == 0f)
            {
                //playerStats.transform.position = playerStats.InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.position; // instead of this do a fast transform, not a blink
                //playerStats.transform.rotation = playerStats.InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.rotation;
            }
            else if ( Timer < 0.5f)
            {
                playerStats.gameObject.transform.position = Vector3.Lerp(playerStats.gameObject.transform.position, playerStats.InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.position, 15f * Time.deltaTime);
                playerStats.gameObject.transform.rotation = Quaternion.Lerp(playerStats.gameObject.transform.rotation, playerStats.InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.rotation, 15f * Time.deltaTime);
               
            }else if (Timer > 0.5f && Timer < 1f)
            {

            }
            else if (Timer > 1f && Timer < 2f)
            {
                playerStats.gameObject.transform.position = Vector3.Lerp(playerStats.gameObject.transform.position, playerStats.InteractingObject.GetComponent<HidingObjectInfo>().HiddenPosition.position, 8 * Time.deltaTime);
                playerStats.gameObject.transform.rotation = Quaternion.Lerp(playerStats.gameObject.transform.rotation, playerStats.InteractingObject.GetComponent<HidingObjectInfo>().HiddenPosition.rotation, 8* Time.deltaTime);
                playerStats.ConcealmentValue = 0.5f; //change into a decreasing function
            } 
            Timer += Time.deltaTime;
            if (Timer > 2f)
            {
                playerStats.PlayerCamera.GetComponent<CameraMovement>().CameraState = 2;
                playerStats.InsideHidingObject = true;
                playerStats.HidingPosition = playerStats.InteractingObject.GetComponent<HidingObjectInfo>().HiddenPosition;
                Timer = 0;
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