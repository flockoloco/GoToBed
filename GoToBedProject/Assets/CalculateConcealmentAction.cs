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
    public float brightness2; // http://www.nbdtech.com/Blog/archive/2008/04/27/Calculating-the-Perceived-Brightness-of-a-Color.aspx
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
        if (Physics.Raycast(playerStats.transform.position, Vector3.down, out hit))
        {

            Renderer hitRenderer = hit.collider.GetComponent<Renderer>();
            LightmapData lightmapData = LightmapSettings.lightmaps[hitRenderer.lightmapIndex];
            Texture2D lightmapTex = lightmapData.lightmapColor;
            Vector2 pixelUV = hit.lightmapCoord;

            Color surfaceColor = lightmapTex.GetPixelBilinear(pixelUV.x, pixelUV.y);
            this.surfaceColor = surfaceColor;
            Color aaaaa = surfaceColor.linear;

        }

        // BRIGHTNESS APPROX
        brightness1 = (surfaceColor.r + surfaceColor.r + surfaceColor.b + surfaceColor.g + surfaceColor.g + surfaceColor.g) / 6;


        // BRIGHTNESS
        brightness2 = Mathf.Sqrt((surfaceColor.r * surfaceColor.r * 0.2126f + surfaceColor.g * surfaceColor.g * 0.7152f + surfaceColor.b * surfaceColor.b * 0.0722f));

    }
}
