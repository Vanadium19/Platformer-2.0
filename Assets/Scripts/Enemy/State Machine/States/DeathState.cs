using UnityEngine;

public class DeathState : AbstractState
{
    private void OnEnable()
    {
        StateAnimator.SetTrigger(ProjectData.AnimatorTriggers.DeathHash);
    }
}
