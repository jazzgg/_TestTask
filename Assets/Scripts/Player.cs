using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IRestartable, IStopable
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Animator _animatorComponent;
    [SerializeField]
    private Transform _checkGroundPosition;
    private PlayerMover _mover;
    private PlayerJumper _jumper;
    [SerializeField]
    private PlayerAttacker _attacker;
    private PlayerAnimator _animator;
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;

    public void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = new PlayerInput();
        _input.Enable();
        _jumper = new PlayerJumper(_rigidbody, _checkGroundPosition);
        _mover = new PlayerMover(transform);
        _attacker.Initialize();
        _animator = new PlayerAnimator(_animatorComponent, _mover.CheckMove, _jumper.CheckGround);

        _input.Input.Jump.started += context => _jumper.Jump();
        _input.Input.Shoot.performed += context => _attacker.Attack();
    }
    public void Stop()
    {
        _input.Disable();
    }

    public void Restart()
    {
        _input.Enable();
    }
    private void Update()
    {
        _mover.CustomUpdate(Time.deltaTime, _input.Input.Movement.ReadValue<float>());
        _animator.CustomUpdate();
    }
    private void OnDestroy()
    {
        _input.Disable();
    }

   
}
