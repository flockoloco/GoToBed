using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Enemy Can Find")]
public class EnemyCanFindThePlayer : Condition
{
    [SerializeField]
    private bool negation;
    [SerializeField]
    private bool useRaycast;
    private float concPlayer;
    private float distanceToTarget;
    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override bool Test(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        if (enemyStats.Searching.Equals(true) && !fsm.GetAgent().waypoints.Count.Equals(0))
        {
            concPlayer = enemyStats.Target.GetComponent<PlayerStats>().ConcealmentValue;
            distanceToTarget = Vector3.Distance(enemyStats.Target.transform.position, fsm.gameObject.transform.position);
            distanceToTarget = distanceToTarget * 1.5f;
            if (((concPlayer * 10) / distanceToTarget) > enemyStats.VisionDetection)
            {
                if (useRaycast)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(fsm.gameObject.transform.position, enemyStats.Target.transform.position - fsm.gameObject.transform.position, out hit, Mathf.Infinity, LayerMask.GetMask("Player")))
                    {
                        Debug.DrawRay(fsm.gameObject.transform.position, enemyStats.Target.transform.position - fsm.gameObject.transform.position, Color.green);
                        if (hit.transform.tag == enemyStats.Target.gameObject.tag)
                        {
                            float lookingDirection = Vector3.Angle(fsm.gameObject.transform.forward, (enemyStats.Target.transform.position - fsm.gameObject.transform.position).normalized);
                            if (lookingDirection < 80f)
                            {
                                return !negation;
                            }
                        }
                    }
                }
                else
                {
                    return negation;
                }
            }
        }
        return negation;
    }

    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
