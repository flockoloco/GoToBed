using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Enemy Door Interaction Condition")]
public class EnemyDoorInteractionCondition : Condition
{
    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override bool Test(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        RaycastHit hit;
        if (Physics.Raycast(enemyStats.transform.position,  (new Vector3(enemyStats.Agent.steeringTarget.x, enemyStats.transform.position.y, enemyStats.Agent.steeringTarget.z) - enemyStats.transform.position).normalized, out hit, 3, LayerMask.GetMask("Interactable")))
        { 
            if (FindParentWithTag(hit.collider.gameObject, Globals.GameTags.Door.ToString(), enemyStats))
            {
                if (enemyStats.OldDoorScript.Open.Equals(false) && enemyStats.OldDoorScript.Locked.Equals(false))
                {
                    enemyStats.StopAgent();
                    enemyStats.OldCurrentWaypoint = enemyStats.CurrentWaypoint;
                    enemyStats.OldSearchList = enemyStats.SearchWaypoints;
                    enemyStats.OldState = fsm.CurrentState;
                    enemyStats.OldDoorScript.DoorInteraction(enemyStats);
                    return true;
                }   
            }
        }
        return false;
    }

    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
    private GameObject FindParentWithTag(GameObject childObject, string tag, EnemyStats enemyStats) //method gotten from a forum
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
                enemyStats.OldDoorScript = t.parent.gameObject.GetComponent<DoorScript>();
                return t.parent.gameObject;
            }
            t = t.parent.transform;
        }

        return null; // Could not find a parent with given tag.
    }
}
