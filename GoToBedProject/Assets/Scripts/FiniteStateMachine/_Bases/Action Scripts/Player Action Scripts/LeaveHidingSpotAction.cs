using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Exit Hiding")]
public class LeaveHidingSpotAction : Action
{
    [SerializeField]
    PlayerHidingAction _hidingAction;
    [SerializeField]
    float _timer = 0;
    [SerializeField]
    Quaternion directionToLookAt;

    public float Timer { get => _timer; set => _timer = value; }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        if (Timer == 0f)
        {
            Debug.Log("entering the first timer");
            playerStats.PlayerCamera.CameraState = 3;
            playerStats.PlayerCamera.CameraXAxis = 0;
            playerStats.PlayerCamera.CameraYAxis = 0;
            if (playerStats.InteractingObject.GetComponent<HidingObjectInfo>().ObjectAnimator != null)
            {
                playerStats.InteractingObject.GetComponent<HidingObjectInfo>().ObjectAnimator.Play(0);
            }
            

            Timer += Time.deltaTime;
            HidingObjectInfo hidingObject = playerStats.InteractingObject.GetComponent<HidingObjectInfo>();
            //dunno
        }
        else if (Timer < 1f)
        {
            Timer += Time.deltaTime;
            HidingObjectInfo hidingObject = playerStats.InteractingObject.GetComponent<HidingObjectInfo>();
            playerStats.gameObject.transform.position = Vector3.Lerp(playerStats.gameObject.transform.position, hidingObject.EntryPosition.position, 8 * Time.deltaTime);
            playerStats.gameObject.transform.rotation = Quaternion.Lerp(playerStats.gameObject.transform.rotation,hidingObject.HiddenPosition.rotation  , 8 * Time.deltaTime);




            //rotate us over time according to speed until we are in the required rotation
            playerStats.PlayerCamera.gameObject.transform.rotation = Quaternion.Slerp(playerStats.PlayerCamera.gameObject.transform.rotation, hidingObject.HiddenPosition.rotation, Time.deltaTime * 8f);



        }
        else if (Timer > 1f && Timer < 1.5f)
        {
            Timer += Time.deltaTime;
            //close door animation?
        }
        else if (Timer > 1.5f)
        {
            HidingObjectInfo hidingObject = playerStats.InteractingObject.GetComponent<HidingObjectInfo>();
            playerStats.gameObject.transform.position = hidingObject.EntryPosition.position;
            playerStats.gameObject.transform.rotation = hidingObject.HiddenPosition.rotation;
            playerStats.PlayerCamera.gameObject.transform.rotation = hidingObject.HiddenPosition.rotation;

            Timer = 0;
            _hidingAction.Timer = 0;
            playerStats.InsideHidingObject = false;
            playerStats.PlayerCamera.CameraState = 1;
            
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
