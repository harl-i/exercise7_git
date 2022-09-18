using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Enemy : PhysicsObject
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        TargetVelocity = Vector2.left;
    }

    protected override void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Border>(out Border border))
        {
            TargetVelocity *= -1;

            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
    }
}
