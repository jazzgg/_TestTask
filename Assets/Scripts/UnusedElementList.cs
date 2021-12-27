using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnusedElementList<T> 
{
    private List<T> _unusedElements;

    public UnusedElementList(T[] elements)
    {
        _unusedElements = new List<T>(elements.Length);

        foreach (var spawnPoint in elements)
        {
            _unusedElements.Add(spawnPoint);
        }
    }
    public T PeekRandom()
    {
        var element = _unusedElements[Random.Range(0, _unusedElements.Count)];
        Remove(element);

        return element;
    }
    private void Remove(T element)
    {
        _unusedElements.Remove(element);
    }
}
