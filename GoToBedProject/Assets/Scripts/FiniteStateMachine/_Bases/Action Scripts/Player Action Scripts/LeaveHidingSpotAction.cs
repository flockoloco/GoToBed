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
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        if (_timer == 0f)
        {
            _timer += Time.deltaTime;
            //dunno
        }
        else if (_timer < 1f)
        {
            _timer += Time.deltaTime;
            HidingObjectInfo hidingObject = playerStats.InteractingObject.GetComponent<HidingObjectInfo>();
            playerStats.gameObject.transform.position = Vector3.Lerp(playerStats.gameObject.transform.position, hidingObject.EntryPosition.position, 8 * Time.deltaTime);
            playerStats.gameObject.transform.rotation = Quaternion.Lerp(playerStats.gameObject.transform.rotation, hidingObject.EntryPosition.rotation, 8 * Time.deltaTime);
        }
        else if (_timer > 1f && _timer < 1.5f)
        {
            _timer += Time.deltaTime;
            //close door animation?
        }
        else if (_timer > 1.5f)
        {
            _timer = 0;
            _hidingAction.Timer = 0;
            playerStats.InsideHidingObject = false;
            playerStats.ConcealmentValue = 0.5f;
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
