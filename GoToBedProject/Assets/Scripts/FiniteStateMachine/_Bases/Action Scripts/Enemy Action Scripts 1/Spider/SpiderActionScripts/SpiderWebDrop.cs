using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Spider/WebDrop")]
public class SpiderWebDrop : Action
{
    public int WebAmount = 0;
    [Range(1, 10)]
    public int Intensity;
    private int fixAddNumber = 1;
    private int fixSubNumber = 1;
    public float webDropTimer;
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        webDropTimer += Time.deltaTime;
        float calculation = (WebAmount / fixSubNumber) * Intensity + fixAddNumber;
        if(webDropTimer >= calculation)
        {
            Instantiate(enemyStats.SpiderWeb, enemyStats.SpiderCoccyx.transform.position, Quaternion.Euler(90, 0, 0));
            webDropTimer = 0;
            //devo fazer um get all webs?? 
            WebAmount += 1;
        }
        Debug.Log(calculation);
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
