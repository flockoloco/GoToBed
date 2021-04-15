using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Can See")]
public class EnemiesCanSeeCondition : Condition
{
    [SerializeField]
    private bool negation;
    [SerializeField]
    private float viewAngle;
    [SerializeField]
    private float viewDistance;
    public override bool Test(FiniteStateMachine fsm)
    {
        Vector3 targetDirection = fsm.GetComponent<EnemiesStats>().Target.transform.position - fsm.transform.position; //not normalized
        float angle = Vector3.Angle(targetDirection.normalized, fsm.transform.forward);
        float distance = targetDirection.magnitude;
        if ((angle <= viewAngle) && (distance <= viewDistance))
        {
            return !negation;
        }
        return negation;
    }
}