using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IRestartable, IStopable
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Transform _checkGroundPosition;
    private PlayerMover _mover;
    private PlayerJumper _jumper;
    [SerializeField]
    private PlayerAttacker _attacker;
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;

    public void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = new PlayerInput();
        _input.Enable();
        _jumper = new PlayerJumper(_rigidbody, _checkGroundPosition, _animator);
        _mover = new PlayerMover(transform, _animator);
        _attacker.Initialize();

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
    }
    private void OnDestroy()
    {
        _input.Disable();
    }

   
}
