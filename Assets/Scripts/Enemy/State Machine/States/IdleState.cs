using UnityEngine;

public class IdleState : State
{
    private void OnEnable()
    {
        EnemyAnimatorController.SetBoolParam(ProjectData.AnimatorParams.RunStateHash, false);
    }
}
