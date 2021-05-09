using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Search Noise")]
public class SearchNoiseAction : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        RaycastHit hit;
        if (Physics.Raycast(enemyStats.transform.position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("LevelCollider")))
        {
            if(hit.collider.GetComponent<LevelObjectInfo>().level == enemyStats.Target.gameObject.GetComponent<PlayerStats>().CurrentLevel)
            {
                float distance = Vector3.Distance(enemyStats.Target.transform.position, enemyStats.gameObject.transform.position);
                float attenuation = 0.9f;
                float soundIntensity = enemyStats.Target.GetComponent<PlayerStats>().NoiseValue * Mathf.Pow(attenuation, distance);
                //quanto mais longe mais dificil é do inimigo escutar
                Debug.Log(soundIntensity + " INTENSIDADE DO SOM");
                if (enemyStats.HearingCapability < soundIntensity)
                {
                    enemyStats.heardSomething = true;
                }
                else
                {
                    enemyStats.heardSomething = false;
                }
            }
        }
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
