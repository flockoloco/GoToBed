using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Conditions/PlayerCanSeeEnemy")]
public class PlayerCanSeeEnemyCondition : Condition
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
            if (Vector3.Angle(enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.transform.forward,(enemyStats.transform.position - enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.transform.position).normalized) < 60)
            {
                Ray ray = new Ray(enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.transform.position, (enemyStats.EyesPosition.transform.position - enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.transform.position).normalized);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Enemy", "LevelCollider","Interactable","DoorLayer")))
                {
                    Debug.DrawLine(enemyStats.Target.GetComponent<PlayerStats>().PlayerCamera.transform.position, hit.point);
                    if (hit.transform.tag == enemyStats.gameObject.tag)
                    {
                        return !negation;
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
