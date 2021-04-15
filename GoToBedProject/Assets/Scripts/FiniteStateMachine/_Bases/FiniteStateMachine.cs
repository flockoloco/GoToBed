using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    public State initialState;
    private State currentState;
    private GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        currentState = initialState;
        
    }

    public GameObject GetObject()
    {
        return gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Transition triggeredTransition = null;
        foreach (Transition t in currentState.GetTransitions())
        {
            if (t.IsTriggered(this))
            {
                triggeredTransition = t;
                break;
            }

        }
        List<Action> actions = new List<Action>();
        if (triggeredTransition)
        {
            State targetState = triggeredTransition.GetTargetState();
            actions.Add(currentState.GetExitAction());

            //add if getaction  not null---
            actions.Add(triggeredTransition.GetAction());
            ///----
            actions.Add(targetState.GetEntryAction());
            currentState = targetState;

        }
        else
        {
            foreach (Action a in currentState.GetActions())
            {
                //add if not null---
                actions.Add(a);
                //---
            }
        }
        DoActions(actions);
    }
    private void DoActions(List<Action> actions)
    {
        foreach (Action a in actions)
        {
            if (a != null)
            {
                a.Act(this);
            }
        }
    }
}
