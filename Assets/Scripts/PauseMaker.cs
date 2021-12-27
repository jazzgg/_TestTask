using System.Collections.Generic;
using System;
public class PauseMaker 
{
    private List<IStopable> _stopables;
    private List<IRestartable> _restartables;

    private IPauseEventProvider _pauseEventProvider;
    private IResumeEventProvider _resumeEventProvider;

    public PauseMaker(IPauseEventProvider pauseEventProvider,
        IResumeEventProvider resumeEventProvider)
    {
        _stopables = new List<IStopable>();
        _restartables = new List<IRestartable>();

        _pauseEventProvider = pauseEventProvider;
        _resumeEventProvider = resumeEventProvider;

        _pauseEventProvider.OnPause += MakePause;
        _resumeEventProvider.OnResume += Resume;

    }
    public void AddStopables(params IStopable[] stopables)
    {
        if (stopables.CheckLength() == false) return;

        _stopables.SetList(stopables);
    }
    public void AddRestartables(params IRestartable[] restartables)
    {
        if (restartables.CheckLength() == false) return;

        _restartables.SetList(restartables);
    }
    public void MakePause()
    {
        _stopables.DoForAll(stopable => stopable.Stop());
    }
    public void Resume()
    {
        _restartables.DoForAll(restartable => restartable.Restart());
    }
    public void Dispose()
    {
        _pauseEventProvider.OnPause -= MakePause;
        _resumeEventProvider.OnResume -= Resume;
    }

}
