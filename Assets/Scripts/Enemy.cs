using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public event Action<Enemy> OnDied;

    [SerializeField]
    private int _startHealth;
    private int _health;

    public void Initialize() 
    {
        _health = _startHealth;
    }
    public void GetDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        OnDied?.Invoke(this);
        Destroy(gameObject);
    }
}
