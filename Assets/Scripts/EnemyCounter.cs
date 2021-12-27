using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour, IPauseEventProvider, IRestartable
{
    public event Action OnPause;

    private LinkedList<Enemy> _aliveEnemies;

    public void Initialize()
    {
        _aliveEnemies = new LinkedList<Enemy>();
        var enemies = FindObjectsOfType<Enemy>();

        foreach (var enemy in enemies)
        {
            _aliveEnemies.AddLast(enemy);
            enemy.OnDied += OnEnemyDie;
        }
    }
    public void Restart()
    {
        Initialize();
    }

    private void OnEnemyDie(Enemy enemy)
    {
        enemy.OnDied -= OnEnemyDie;
        _aliveEnemies.Remove(enemy);

        if (_aliveEnemies.Count == 0)
            OnPause?.Invoke();
    }

   
}
