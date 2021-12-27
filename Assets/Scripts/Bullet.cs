using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    private Vector3 _direction;
    private float _speed;
    private int _damage;
    private float _lifeTime;
    public bool IsActive => gameObject.activeInHierarchy;

    public void Initialize(float speed, int damage, float lifeTime)
    {
        _speed = speed;
        _damage = damage;
        _lifeTime = lifeTime;
    }
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
    public void Disable()
    {
        SetActive(false);
    }

    public void Enable()
    {
        SetActive(true);
        StartCoroutine(CountRemove());
    }
    private void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    private IEnumerator CountRemove()
    {
        yield return new WaitForSeconds(_lifeTime);
        Disable();
    }
    private void Update()
    {
        transform.Translate(transform.right * _direction.x * _speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.GetDamage(_damage);
            Disable();
        }
    }
}
