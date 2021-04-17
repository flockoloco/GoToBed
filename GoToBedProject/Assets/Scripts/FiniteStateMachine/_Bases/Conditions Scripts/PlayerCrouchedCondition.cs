using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Player Crounched Condition")]
public class PlayerCrouchedCondition : Condition
{
    [SerializeField]
    private bool negation;
    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats)
    { 
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            if ( fsm.CurrentState.name == "Crouch") // name of crouched action
            {
                Debug.Log(fsm.CurrentState.name + " is the state name");
                RaycastHit[] hits;

                hits = Physics.RaycastAll(playerStats.transform.position, Vector3.up, playerStats.gameObject.GetComponent<MeshRenderer>().bounds.size.y / 2 * 3.1f); //change constants if the % of the crouch changes
                Debug.Log(hits);
                foreach (RaycastHit hit in hits)
                {
                    if (hit.collider.tag == "Wall" || hit.collider.isTrigger == false)  // for now theres just two examples of possibilities
                                                                                        //maybe instead of tags, use mask layer? or something else in common
                    {
                        Debug.Log("crouch blocked");
                        return negation;
                    }
                    else
                    {
                        return !negation;
                    }
                }
            }
            Debug.Log("Player pressed crouch");
            return !negation;
        }
        return negation;
       
    }

    public override bool Test(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        throw new System.NotImplementedException();
    }

    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}