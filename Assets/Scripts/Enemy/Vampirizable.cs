using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStateMachine))]
[RequireComponent(typeof(AnimatorController))]
public class Vampirizable : MonoBehaviour
{
    private EnemyStateMachine _enemyStateMachine;
    private AnimatorController _enemyAnimatorController;

    private void Awake()
    {
        _enemyStateMachine = GetComponent<EnemyStateMachine>();
        _enemyAnimatorController = GetComponent<AnimatorController>();
    }

    private void OnEnable()
    {
        TurnOn(true);
    }

    private void OnDisable()
    {
        TurnOn(false);
    }

    private void TurnOn(bool value)
    {
        _enemyStateMachine.TurnOn(!value);
        _enemyAnimatorController.SetBoolParam(ProjectData.AnimatorParams.VampirizableStateHash, value);

        if (value == true)
            _enemyAnimatorController.SetTrigger(ProjectData.AnimatorTriggers.VampirismHash);
    }
}
