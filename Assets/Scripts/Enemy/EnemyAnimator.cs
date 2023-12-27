using UnityEngine;

public class EnemyAnimator : AnimatorController
{
    private void Update()
    {
        Animator.SetBool(ProjectData.AnimatorParams.RunHash, IsRunning);
    }
}
