using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FiniteStateMachine : MonoBehaviour
{
    [SerializeField]
    private bool playerOrEnemy; // false is player, true is enemy

    [SerializeField]
    private State _initialState;
    [SerializeField]
    private State _currentState;

    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private EnemyStats enemyStats;

    public State InitialState { get => _initialState; set => _initialState = value; }
    public State CurrentState { get => _currentState; set => _currentState = value; }

    void Start()
    {
        CurrentState = InitialState;
    }
    public GameObject GetObject()
    {
        return gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        Transition triggeredTransition = null;
        foreach (Transition t in CurrentState.GetTransitions())
        {
            if (t != null)
            {


                if (playerOrEnemy == false)
                {
                    if (t.IsTriggered(this, playerStats))
                    {
                        triggeredTransition = t;
                        break;
                    }
                }
                else
                {
                    if (t.IsTriggered(this, enemyStats))
                    {
                        triggeredTransition = t;
                        break;
                    }
                }
            }
        }
        List<Action> actions = new List<Action>();
        if (triggeredTransition)
        {
            State targetState = triggeredTransition.GetTargetState();
            actions.Add(CurrentState.GetExitAction());

            //add if getaction  not null---
            actions.Add(triggeredTransition.GetAction());
            ///----
            actions.Add(targetState.GetEntryAction());
            CurrentState = targetState;

        }
        else
        {
            foreach (Action a in CurrentState.GetActions())
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
                if (playerOrEnemy == false)
                {
                    a.Act(this, playerStats); //for now there isnt a all enemies + player branch
                                              //although there already is one in their overloads,
                                              //implement if needed, remove if not
                }
                else
                {
                    a.Act(this, enemyStats);
                }
            }
        }
    }
}
