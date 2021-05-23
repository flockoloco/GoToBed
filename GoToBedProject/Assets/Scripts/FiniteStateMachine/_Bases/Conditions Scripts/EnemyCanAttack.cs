using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Conditions/EnemyCanAttack")]
public class EnemyCanAttack : Condition
{
    [SerializeField]
    private bool negation;
    [SerializeField]
    private bool useRaycast;
    [SerializeField]
    private float attackRange;
    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override bool Test(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        float distanceBetween = Vector3.Distance(enemyStats.Target.gameObject.transform.position, fsm.gameObject.transform.position);
        
        if (distanceBetween < attackRange)
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
        }
        else
        {
            return negation;
        }
        return negation;
    }

    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
