using System;
using System.Collections;
using System.Collections.Generic;
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
        }
        else
        {
            if (_checkMove())
            {
                _animator.SetBool("isRunning", true);
            }
            else
            {
                _animator.SetBool("isRunning", false);
            }
        }
    }
}
