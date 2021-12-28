using System;
public interface IPauseEventProvider
{
    event Action OnPause;
}
