using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Crouch")]
public class CrouchAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        Debug.Log("Aaa");
    }

}
