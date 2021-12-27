using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable 
{
    bool IsActive { get; }
    void Enable();
    void Disable();
}
