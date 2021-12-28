using UnityEngine;

public class GameStatsCounter : IStopable, IRestartable, IStatsProvider 
{
    private float _startTime;
    private float _spentTime;

    public float SpentTime => _spentTime;

    public GameStatsCounter()
    {
        UpdateTimer();
    }

    public void Stop()
    {
        var spentTime = Time.time - _startTime;
        _spentTime = Mathf.Round(spentTime);
    }

    public void Restart()
    {
        UpdateTimer();
    }
    private void UpdateTimer()
    {
        _startTime = Time.time;
    }
}
