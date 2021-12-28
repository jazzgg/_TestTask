using System;
using UnityEngine;

public class PlayerAnimator 
{
    private Animator _animator;

    private Func<bool> _checkMove;
    private Func<bool> _checkGround;

    public PlayerAnimator(Animator animator, Func<bool> checkMove, Func<bool> checkGround)
    {
        _checkMove = checkMove;
        _checkGround = checkGround;
        _animator = animator;
    }
    public void CustomUpdate()
    {
        if (_checkGround() == false)
        {
            _animator.SetTrigger("Jump");
            SetRunningState(RunningStates.Null);
        }
        else
        {
            if (_checkMove())
            {
                SetRunningState(RunningStates.isRunning);
            }
            else
            {
                SetRunningState(RunningStates.isNotRunning);
            }
        }
    }
    private void SetRunningState(RunningStates state)
    {
        _animator.SetInteger("isRunning", ((int)state));
    }
    private enum RunningStates
    {
        isNotRunning,
        isRunning,
        Null
    }
}
