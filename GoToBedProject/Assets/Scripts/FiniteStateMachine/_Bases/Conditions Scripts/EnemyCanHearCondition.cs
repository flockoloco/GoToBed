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
                    float distance = Vector3.Distance(enemyStats.Target.transform.position, enemyStats.gameObject.transform.position);
                    float attenuation = 0.9f;
                    float soundIntensity = enemyStats.Target.GetComponent<PlayerStats>().NoiseValue * Mathf.Pow(attenuation, distance);
                    //quanto mais longe mais dificil é do inimigo escutar
                    //Debug.Log(soundIntensity + " INTENSIDADE DO SOM");
                    if (enemyStats.HearingCapability < soundIntensity)
                    {
                        //Funciona, polish search
                        return !negation;  
                    }
                    else
                    {
                        return negation;
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
