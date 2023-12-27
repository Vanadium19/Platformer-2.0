using UnityEngine;

public class PlayerAnimator : AnimatorController
{
    private void Update()
    {
        Animator.SetBool(ProjectData.AnimatorParams.RunHash, IsRunning);
    }
}
