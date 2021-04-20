﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Move")]
public class PlayerMoveAction : Action
{
    
    Vector3 velocity;
    bool isGrounded;

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        isGrounded = Physics.CheckSphere(playerStats.GroundCheck.position, playerStats.GroundDistance, playerStats.Groundmask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = fsm.transform.right * x + fsm.transform.forward * z;

        playerStats.PlayerController.Move(move * playerStats.MoveSpeed * Time.deltaTime);
        //apply slow if webbed

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