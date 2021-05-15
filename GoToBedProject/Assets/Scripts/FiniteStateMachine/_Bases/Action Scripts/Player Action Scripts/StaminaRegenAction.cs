using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Stamina Regen Action")]
public class StaminaRegenAction : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        if (playerStats.StaminaObject.GetComponent<Image>().fillAmount < 1f)
        {
            playerStats.StaminaParentObject.SetActive(true);
            playerStats.StaminaObject.GetComponent<Image>().fillAmount += 0.0005f * Time.deltaTime;
            if (playerStats.StaminaObject.GetComponent<Image>().fillAmount > 1f)
            {
                playerStats.StaminaObject.GetComponent<Image>().fillAmount = 1f;
            }
        }
        else
        {
            playerStats.StaminaParentObject.SetActive(false);
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
