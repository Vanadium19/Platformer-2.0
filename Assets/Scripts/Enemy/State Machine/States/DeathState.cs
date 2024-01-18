using UnityEngine;

public class DeathState : State
{
    private void OnEnable()
    {
        EnemyAnimatorController.SetTrigger(ProjectData.AnimatorTriggers.DeathHash);
    }
}
