using UnityEngine;

public class PlayerAnimator : AbstractAnimator
{
    private void Update()
    {
        Animator.SetBool(ProjectData.AnimatorParams.RunHash, IsRunning);
    }
}
