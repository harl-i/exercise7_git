using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerPlatformerController : PhysicsObject
{
    public float jumpTakeOffSpeed = 7f;
    public float maxSpeed = 7f;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && Grounded)
        {
            Velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (Velocity.y > 0)
            {
                Velocity.y *= 0.5f;
            }
        }

        bool flipSpite = (_spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < -0.01f));
        if (flipSpite)
        {
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }

        _animator.SetBool(AnimatorPlayerAnimation.HashAnimationNames.IsGround, Grounded);
        _animator.SetFloat(AnimatorPlayerAnimation.HashAnimationNames.Velocity, Mathf.Abs(Velocity.x) / maxSpeed);

        TargetVelocity = move * maxSpeed;
    }
}
