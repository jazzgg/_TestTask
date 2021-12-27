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
    [SerializeField]
    private GameStatsCounter _gameStatsCounter;
    private PauseMaker _pauseMaker;
    private Disposer _disposer;

    private void Start()
    {
        _player.Initialize();
        _enemySpawner.Initialize();
        _enemyCounter.Initialize();
        _gameStatsCounter = new GameStatsCounter();
        _endScreen.Initialize(_gameStatsCounter);
        _pauseMaker = new PauseMaker(_enemyCounter, _endScreen);
        _pauseMaker.AddStopables(_gameStatsCounter, _player, _endScreen);
        _pauseMaker.AddRestartables(_gameStatsCounter, _endScreen, _enemySpawner, _enemyCounter, _player);
    }
}
