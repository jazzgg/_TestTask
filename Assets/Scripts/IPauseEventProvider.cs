using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IPauseEventProvider
{
    event Action OnPause;
}
