using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/EnemyCanSee")]
public class EnemyCanSeeCondition : Condition
{

    [SerializeField]
    private Transform blablac;
    [SerializeField]
    private bool negation;
    [SerializeField]
    private float viewAngle;
    [SerializeField]
    private float viewDistance;
    public override bool Test(FiniteStateMachine fsm)
    {
        Vector3 targetDirection = fsm.GetComponent<EnemyStats>().Target.transform.position - fsm.transform.position; //not normalized
        float angle = Vector3.Angle(targetDirection.normalized, fsm.transform.forward);
        float distance = targetDirection.magnitude;
        if ((angle <= viewAngle) && (distance <= viewDistance))
        {
            return !negation;
        }
        return negation;
    }
}