using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : State
{
    private bool grounded;

    public JumpingState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        //SoundManager.Instance.PlaySound(SoundManager.Instance.jumpSounds);
        grounded = false;
        Jump();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (grounded)
        {
            //character.TriggerAnimation(landParam);
            //SoundManager.Instance.PlaySound(SoundManager.Instance.landing);
            stateMachine.ChangeState(character.standing);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        //grounded = character.CheckCollisionOverlap(character.transform.position);
    }

    private void Jump()
    {
        //character.transform.Translate(Vector3.up * (character.CollisionOverlapRadius + 0.1f));
        //character.ApplyImpulse(Vector3.up * character.JumpForce);
        //character.TriggerAnimation(jumpParam);
    }
}
