using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : State
{
    protected float speed;
    protected float rotationSpeed;

    private float horizontalInput;

    public GroundedState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        horizontalInput = 0.0f;
    }

    public override void Exit() 
    { 
        base.Exit();
        character.ResetMoveParams();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        horizontalInput = Input.GetAxis("Horizontal");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        character.Move(horizontalInput);
    }
}
