using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Stamina Action")]
public class PlayerStaminaAction : Action
{
    public float maxStamina = 1f;

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    { 
        playerStats.StaminaParentObject.SetActive(true);
        if (playerStats.StaminaObject.GetComponent<Image>().fillAmount > 0.002f)
        {
            playerStats.StaminaObject.GetComponent<Image>().fillAmount -= 0.002f;
        }
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}