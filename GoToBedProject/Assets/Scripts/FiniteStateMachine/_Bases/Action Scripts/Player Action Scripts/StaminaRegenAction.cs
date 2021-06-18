using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VectorGraphics;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Stamina Regen Action")]
public class StaminaRegenAction : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        SVGImage imageColor = playerStats.StaminaObject.GetComponent<SVGImage>();
        
      


        if ( imageColor.color.a > 0)
        {
            float newAValue = Mathf.Clamp(imageColor.color.a - (0.2f * Time.deltaTime),0,1);
            imageColor.color = new Color(imageColor.color.r, imageColor.color.g, imageColor.color.b, newAValue);
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
