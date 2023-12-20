using UnityEngine;

public class EnemyAnimator : AbstractAnimator
{
    private void Update()
    {
        Animator.SetBool(ProjectData.AnimatorParams.RunHash, IsRunning);
    }
}
