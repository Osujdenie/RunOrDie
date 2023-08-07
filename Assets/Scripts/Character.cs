using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public StateMachine movementSM;
    public StandingState standing;
    public JumpingState jumping;

    private int horizonalMoveParam;

    public float MovementSpeed;

    private void Start()
    {
        movementSM = new StateMachine();

        standing = new StandingState(this, movementSM);

        jumping = new JumpingState(this, movementSM);

        movementSM.Initialize(standing);
    }
    private void Update()
    {
        movementSM.CurrentState.HandleInput();

        movementSM.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        movementSM.CurrentState.PhysicsUpdate();
    }

    public void Move(float speed)
    {
        Vector3 targetVelocity = speed * transform.forward * Time.deltaTime;
        targetVelocity.y = GetComponent<Rigidbody>().velocity.x;
        GetComponent<Rigidbody>().velocity = targetVelocity;

        //GetComponent<Rigidbody>().angularVelocity = rotationSpeed * Vector3.up * Time.deltaTime;

        if (targetVelocity.magnitude > 0.01f || GetComponent<Rigidbody>().angularVelocity.magnitude > 0.01f)
        {
            //SoundManager.Instance.PlayFootSteps(Mathf.Abs(speed));
        }
    }

    public void ResetMoveParams()
    {
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //anim.SetFloat(horizonalMoveParam, 0f);
    }
}
