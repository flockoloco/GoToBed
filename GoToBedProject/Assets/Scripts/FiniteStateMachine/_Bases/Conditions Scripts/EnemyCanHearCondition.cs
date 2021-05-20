using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Enemy Can Hear")]
public class EnemyCanHearCondition : Condition
{
    [SerializeField]
    private bool negation;
    [SerializeField]
    private bool useRaycast;
    [SerializeField]
    private bool useHearToChase;
    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override bool Test(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        if (useRaycast)
        {
            RaycastHit hit;
            if (Physics.Raycast(enemyStats.transform.position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("LevelCollider")))
            {
                if (hit.collider.GetComponent<LevelObjectInfo>().level == enemyStats.Target.gameObject.GetComponent<PlayerStats>().CurrentLevel)
                {
                    float lookingDirection = Vector3.Angle(fsm.gameObject.transform.forward, (enemyStats.Target.transform.position - fsm.gameObject.transform.position).normalized);
                    float distance = Vector3.Distance(enemyStats.Target.transform.position, enemyStats.gameObject.transform.position);
                    float attenuation = 0.9f;
                    float soundIntensity = enemyStats.Target.GetComponent<PlayerStats>().NoiseValue * Mathf.Pow(attenuation, distance);
                    if (useHearToChase)
                    {
                        if (distance < 10f)
                        {
                            if (lookingDirection < 160f && enemyStats.HearingCapability < soundIntensity)
                            {
                                return !negation;
                            }
                            else
                            {
                                return negation;
                            }
                        }
                        else
                        {
                            return negation;
                        }
                    }
                    else
                    {
                        if (enemyStats.HearingCapability < soundIntensity)
                        {
                            return !negation;
                        }
                        else
                        {
                            return negation;
                        }
                    }
                }
            }
        }
        return negation;
    }

    public override bool Test(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
