using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppStart : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private EnemySpawner _enemySpawner;
    [SerializeField]
    private EndScreen _endScreen;
    [SerializeField]
    private EnemyCounter _enemyCounter;
    private PauseMaker _pauseMaker;

    private void Start()
    {
        _player.Initialize();
        _enemySpawner.Initialize();
        _endScreen.Initialize();
        _enemyCounter.Initialize();
        _pauseMaker = new PauseMaker(_enemyCounter, _endScreen, 
            _player, _endScreen, _enemySpawner, _enemyCounter);
    }
}
