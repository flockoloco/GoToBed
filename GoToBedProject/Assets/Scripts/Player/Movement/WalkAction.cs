﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Player/Walk")]
public class WalkAction : Action
{
    public CharacterController playerController;

    public float speed = 6f;
    public float gravity = -19.62f;

    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundmask;

    Vector3 velocity;
    bool isGrounded;


    public override void Act(FiniteStateMachine fsm)
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = fsm.transform.right * x + fsm.transform.forward * z;

        playerController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        playerController.Move(velocity * Time.deltaTime);
    }
}