using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    public EnemyStats enemyStats;
    private Animator animation;
    private void Awake()
    {
        animation = enemyStats.Animator;
    }
    public void StartAnimation(string boolName)
    {
        animation.SetBool(boolName, true);
    }
    public void CancelAnimation(string boolName)
    {
        animation.SetBool(boolName, false);
    }
    public void StateAnimation(string stateName, int stateNumber)
    {
        animation.SetInteger(stateName, stateNumber);
    }
}
