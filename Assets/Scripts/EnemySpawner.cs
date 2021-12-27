using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IPauseable
{
    [SerializeField]
    private Enemy _prefab;
    [SerializeField]
    private Transform[] _spawnPoints;
    [SerializeField]
    private int _minEnemyAmount, _maxEnemyAmount;

    private List<Enemy> _enemies;
    private UnusedElementsList<Transform> _clearSpawnPoints;

    public List<Enemy> Enemies => _enemies;
    public void Initialize()
    {
        _enemies = new List<Enemy>();
        _clearSpawnPoints = new UnusedElementsList<Transform>(_spawnPoints);
        SpawnEnemy();
    }

    public void Pause()
    {
        
    }

    public void Resume()
    {
        Initialize();
    }

    private void SpawnEnemy()
    {
        _maxEnemyAmount = Mathf.Clamp(_maxEnemyAmount, _minEnemyAmount, _spawnPoints.Length);
        var enemyAmount = Random.Range(_minEnemyAmount, _maxEnemyAmount);

        for (int i = 0; i < enemyAmount; i++)
        {
            var enemy = Instantiate(_prefab, _clearSpawnPoints.PeekRandom().position, Quaternion.identity, transform);
            _enemies.Add(enemy);
        }
    }
}