using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IPauseable
{
    public event Action OnPause;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;
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
        _mover = new PlayerMover(transform, _spriteRenderer);
        _jumper = new PlayerJumper(_rigidbody, _checkGroundPosition);
        _attacker.Initialize();

        _input.Input.Jump.started += context => _jumper.Jump();
        _input.Input.Shoot.performed += context => _attacker.Attack();
    }
    public void Pause()
    {
        _input.Disable();
    }

    public void Resume()
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