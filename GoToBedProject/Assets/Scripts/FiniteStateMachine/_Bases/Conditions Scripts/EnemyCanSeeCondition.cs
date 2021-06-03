using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/EnemyCanSee")]
public class EnemyCanSeeCondition : Condition
{
    [SerializeField]
    private bool negation;
    [SerializeField]
    private bool useRaycast;
    private float concPlayer;
    private float distanceToTarget;
    
    public override bool Test(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        concPlayer = enemyStats.Target.GetComponent<PlayerStats>().ConcealmentValue;
        distanceToTarget = Vector3.Distance(enemyStats.Target.transform.position, fsm.gameObject.transform.position);
        //aumentar o RADIOUS do inimigo, colocar uma sphere!!
        //fsm.gameObject.transform.GetChild(0).gameObject.transform.localScale = Vector3.one * (concPlayer / distanceToTarget);
        //Debug.DrawRay(enemyStats.transform.position, (enemyStats.Target.transform.position - fsm.transform.position).normalized, Color.yellow, 10f);



        if ((concPlayer * enemyStats.VisionDetection) > distanceToTarget)
        {
                
            if (useRaycast)
            {
                RaycastHit hit;
                if (Physics.Raycast(enemyStats.EyesPosition.transform.position, enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.transform.position - enemyStats.EyesPosition.transform.position, out hit, Mathf.Infinity, LayerMask.GetMask("Player","LevelCollider","DoorLayer")))
                {
                    Debug.Log("im here");
                    //Debug.DrawRay(fsm.gameObject.transform.position, enemyStats.Target.transform.position - fsm.gameObject.transform.position, Color.green);
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
        return negation;
    }
    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        Debug.Log(fsm.gameObject.name + "name of the object;");
        throw new System.NotImplementedException();
    }

    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}