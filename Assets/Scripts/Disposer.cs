using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disposer 
{
    private List<IDisposeable> _disposables;
    public Disposer(params IDisposeable[] disposables)
    {
        _disposables.SetList(disposables);
    }
    public void Dispose()
    {
        _disposables.DoForAll(disposable => disposable.Dispose());
    }
}
