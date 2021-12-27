using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerJumper
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Vector2 _jumpDirection;
    private Transform _checkGroundPosition;
    private float _jumpForce;
    private float _groundCheckRadius;
    public PlayerJumper(Rigidbody2D rigidbody, Transform checkGroundPosition, Animator animator)
    {
        _animator = animator;
        _checkGroundPosition = checkGroundPosition;
        _rigidbody = rigidbody;
        _jumpDirection = new Vector2(0, 1).normalized;
        _jumpForce = 7f;
        _groundCheckRadius = 0.15f;
    }
    public void Jump()
    {
        if (!CheckGround())
            return;
        _rigidbody.AddForce(_jumpDirection * _jumpForce, ForceMode2D.Impulse);
        _animator.SetTrigger("Jump");
    }

    private bool CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_checkGroundPosition.position, _groundCheckRadius);
        if (colliders.Length == 0)
            return false;

        Debug.Log("true");
        return colliders.Any(collider => collider.TryGetComponent(out Ground ground));
    }
}
