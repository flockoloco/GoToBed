using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Calculate Concealment")]
public class CalculateConcealmentAction : Action
{
    [SerializeField]
    public Color surfaceColor;
    [SerializeField]
    public float brightness1; // http://stackoverflow.com/questions/596216/formula-to-determine-brightness-of-rgb-color 
    [SerializeField]
    public LayerMask layerMask;


    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        if(fsm.CurrentState.name == "Stand")
        {
            Calculate(fsm,playerStats);
            playerStats.ConcealmentValue = brightness1;
        }
        else if(fsm.CurrentState.name == "Crouch")
        {
            Calculate(fsm, playerStats);
            playerStats.ConcealmentValue = brightness1 / 2;
        }
        else if(fsm.CurrentState.name == "Run")
        {
            Calculate(fsm, playerStats);
            playerStats.ConcealmentValue = brightness1 * 2;
        }
        else if (fsm.CurrentState.name == "Hide")
        {
            playerStats.ConcealmentValue = 0;
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
    void Calculate(FiniteStateMachine fsm , PlayerStats playerStats)
    {
        RaycastHit hit;
        Ray ray = new Ray(playerStats.transform.position, Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction * 5);
        if (Physics.Raycast(playerStats.transform.position, Vector3.down, out hit,Mathf.Infinity, LayerMask.GetMask("LevelCollider")))
        {
            Renderer hitRenderer = hit.collider.GetComponent<Renderer>();
            LightmapData lightmapData = LightmapSettings.lightmaps[hitRenderer.lightmapIndex];
            Texture2D lightmapTex = lightmapData.lightmapColor;
            Vector2 pixelUV = hit.lightmapCoord;

            Color surfaceColor = lightmapTex.GetPixelBilinear(pixelUV.x, pixelUV.y);
            this.surfaceColor = surfaceColor;


        }
        
        // BRIGHTNESS APPROX
        float br1 = (surfaceColor.r + surfaceColor.r + surfaceColor.b + surfaceColor.g + surfaceColor.g + surfaceColor.g) / 6;
        brightness1 = (br1 - 0.4f) / (5f - 0.4f);

    }
}
