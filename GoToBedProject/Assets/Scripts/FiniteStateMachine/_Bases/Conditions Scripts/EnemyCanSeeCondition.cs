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

    public override bool Test(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        Vector3 targetDirection = fsm.GetAgent().target.transform.position - fsm.transform.position; //not normalized
        float angle = Vector3.Angle(targetDirection.normalized, fsm.transform.forward);
        float distance = targetDirection.magnitude;
        if ((angle <= viewAngle) && (distance <= viewDistance))
        {
            if (useRaycast)
            {
                Ray ray = new Ray(fsm.transform.position + (fsm.transform.forward / 2), targetDirection.normalized);
                RaycastHit hit;
                Debug.DrawRay(ray.origin, ray.direction, Color.red);
                if (Physics.Raycast(ray, out hit, viewDistance, LayerMask.GetMask("Level")))
                {
                    Debug.Log(hit.transform.name);
                    if (hit.transform.tag == fsm.GetAgent().target.tag)
                    {
                        return !negation;
                    }
                }
            }
            else
            {
                return !negation;
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