using System.Collections.Generic;
using System;
public class PauseMaker 
{
    private List<IPauseable> _pauseables;

    private IPauseEventProvider _pauseEventProvider;
    private IResumeEventProvider _resumeEventProvider;

    public PauseMaker(IPauseEventProvider pauseEventProvider,
        IResumeEventProvider resumeEventProvider,
        params IPauseable[] pauseables)
    {
        if (pauseables.Length == 0) return;

        _pauseEventProvider = pauseEventProvider;
        _resumeEventProvider = resumeEventProvider;

        _pauseEventProvider.OnPause += MakePause;
        _resumeEventProvider.OnResume += Resume;

        _pauseables = new List<IPauseable>();

        foreach (var pauseable in pauseables)
        {
            _pauseables.Add(pauseable);
        }
    }
    public void AddPauseable(IPauseable pauseable)
    {
        _pauseables.Add(pauseable);
    }
    public void MakePause()
    {
        DoForAll(pauseable => pauseable.Pause());
    }
    public void Resume()
    {
        DoForAll(pauseable => pauseable.Resume());
    }
    public void Dispose()
    {
        _pauseEventProvider.OnPause -= MakePause;
        _resumeEventProvider.OnResume -= Resume;
    }
    private void DoForAll(Action<IPauseable> predicate)
    {
        foreach (var pauseable in _pauseables)
        {
            predicate(pauseable);
        }
    }
}
