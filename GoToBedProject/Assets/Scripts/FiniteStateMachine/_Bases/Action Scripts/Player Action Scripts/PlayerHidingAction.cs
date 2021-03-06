using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Hiding")]
public class PlayerHidingAction : Action
{
    [SerializeField]
    private float _timer = 0;
    [SerializeField]
    private LeaveHidingSpotAction leavingHidingAction;

    public float Timer { get => _timer; set => _timer = value; }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        if (!playerStats.InsideHidingObject)
        {
            if (Timer == 0f)
            {
                Timer += Time.deltaTime;
                playerStats.PlayerCamera.CameraXAxis = 0;
                playerStats.PlayerCamera.CameraYAxis = 0;
                playerStats.PlayerCamera.CameraState = 3;
                if (playerStats.InteractingObject.GetComponent<HidingObjectInfo>().ObjectAnimator != null)
                {
                    playerStats.InteractingObject.GetComponent<HidingObjectInfo>().ObjectAnimator.Play(0);
                }
                //playerStats.transform.position = playerStats.InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.position; // instead of this do a fast transform, not a blink
                //playerStats.transform.rotation = playerStats.InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.rotation;
            }
            else if ( Timer < 0.75f)
            {
                Timer += Time.deltaTime;
                playerStats.gameObject.transform.position = Vector3.Lerp(playerStats.gameObject.transform.position, playerStats.InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.position, 15f * Time.deltaTime);
                playerStats.gameObject.transform.rotation = Quaternion.Lerp(playerStats.gameObject.transform.rotation, playerStats.InteractingObject.GetComponent<HidingObjectInfo>().EntryPosition.rotation, 15f * Time.deltaTime);
               
            }
            else if (Timer > 0.75f && Timer < 1.25f)
            {
                Timer += Time.deltaTime;
                playerStats.gameObject.transform.position = Vector3.Lerp(playerStats.gameObject.transform.position, playerStats.InteractingObject.GetComponent<HidingObjectInfo>().HiddenPosition.position, 8 * Time.deltaTime);
                playerStats.gameObject.transform.rotation = Quaternion.Lerp(playerStats.gameObject.transform.rotation, playerStats.InteractingObject.GetComponent<HidingObjectInfo>().HiddenPosition.rotation, 8* Time.deltaTime);
            } 
            else if (Timer > 1.25f)
            {
                playerStats.PlayerCamera.CameraState = 2;
                playerStats.InsideHidingObject = true;
                playerStats.HidingPosition = playerStats.InteractingObject.GetComponent<HidingObjectInfo>().HiddenPosition;
                Timer = 0;
                leavingHidingAction.Timer = 0;
                playerStats.UIInteractionTextObject.ChangeText("Get out");
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