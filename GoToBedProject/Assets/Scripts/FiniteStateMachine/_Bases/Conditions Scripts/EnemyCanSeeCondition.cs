using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/EnemyCanSee")]
public class EnemyCanSeeCondition : Condition
{
    [SerializeField]
    private bool negation;
    [SerializeField]
    private float viewAngle;
    [SerializeField]
    private float viewDistance;
    [SerializeField]
    private bool useRaycast;
    private float concPlayer;
    private float distanceToTarget;
    public override bool Test(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        viewDistance = 20f;
        concPlayer = enemyStats.Target.GetComponent<PlayerStats>().ConcealmentValue;
        distanceToTarget = Vector3.Distance(enemyStats.Target.transform.position, fsm.gameObject.transform.position);
        if ((concPlayer / distanceToTarget) > enemyStats.VisionDetection)
        {
            if (useRaycast)
            {
                RaycastHit hit;
                if (Physics.Raycast(fsm.gameObject.transform.position, enemyStats.Target.transform.position - fsm.gameObject.transform.position, out hit, Mathf.Infinity, LayerMask.GetMask("Player")))
                {
                    if (hit.transform.tag == enemyStats.Target.gameObject.tag)
                    {
                        float lookingDirection = Vector3.Angle(fsm.transform.position, fsm.transform.position - enemyStats.Target.transform.position);
                        if (lookingDirection < 180f)
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
        return negation;
    }
    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}