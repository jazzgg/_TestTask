using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Gun : AttackTool
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Bullet _prefab;
    [SerializeField]
    private Transform _bulletSpawnPoint;
    [SerializeField]
    private int _bulletAmount;
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private float _bulletLifeTime;
    private Pool<Bullet> _bullets;
    public override void Initialize()
    {
        var bullets = new List<Bullet>(_bulletAmount);

        for (int i = 0; i < _bulletAmount; i++)
        {
            var bullet = Instantiate(_prefab);
            bullets.Add(bullet);
            bullet.Initialize(_bulletSpeed, _damage, _bulletLifeTime);
        }

        _bullets = new Pool<Bullet>(bullets);
    }
    public override void Attack()
    {
        var bulletDirection = new Vector2(_bulletSpawnPoint.position.x - transform.position.x, 0).normalized;
        var bullet = _bullets.GetElement();
        bullet.SetPosition(_bulletSpawnPoint.position);
        bullet.SetDirection(bulletDirection);
        _animator.SetTrigger("Shoot");
    }
}
