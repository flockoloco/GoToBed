using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Move")]
public class PlayerMoveAction : Action
{
    
    Vector3 velocity;
    bool isGrounded;
    public Vector3 moveDirection = Vector3.zero;

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        //remove later, make into a separate action that only messes with the cds
        playerStats.InteractionCoolDown += Time.deltaTime;

        isGrounded = Physics.CheckSphere(playerStats.GroundCheck.position, playerStats.GroundDistance, playerStats.Groundmask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (fsm.transform.right * x + fsm.transform.forward * z);
        if (move.magnitude > 1)
        { 
            move = move.normalized;
        }
        
        

        moveDirection = move;

        playerStats.PlayerController.Move(move * Time.deltaTime * playerStats.MoveSpeed);
      

        playerStats.PlayerCurrentVelocity = playerStats.PlayerController.velocity.magnitude;

        velocity.y += playerStats.Gravity * Time.deltaTime;

        playerStats.PlayerController.Move(velocity * Time.deltaTime);
        
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