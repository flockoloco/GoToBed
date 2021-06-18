using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VectorGraphics;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Stamina Action")]
public class PlayerStaminaAction : Action
{
    public float maxStamina = 1f;

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        SVGImage staminaImage = playerStats.StaminaObject.GetComponent<SVGImage>();
        if (staminaImage.color.a < 1- 0.002f)
        {
            float newAValue = Mathf.Clamp( staminaImage.color.a + (0.4f * Time.deltaTime),0,1);


            staminaImage.color =  new Color(staminaImage.color.r, staminaImage.color.g, staminaImage.color.b, newAValue);
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