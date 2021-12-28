using System.Collections.Generic;
using UnityEngine;
public class Disposer : MonoBehaviour 
{
    private List<IDisposeable> _disposables;
    public void Initialize (params IDisposeable[] disposables)
    {
        if (disposables.CheckLength() == false) return;

        _disposables = new List<IDisposeable>();
        _disposables.SetList(disposables);
    }
    private void OnDestroy()
    {
        _disposables.DoForAll(disposable => disposable.Dispose());
    }
}
