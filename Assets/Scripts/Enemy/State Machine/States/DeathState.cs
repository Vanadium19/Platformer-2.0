using UnityEngine;

public class DeathState : State
{
    private void OnEnable()
    {
        AnimatorController.SetTrigger(ProjectData.AnimatorTriggers.DeathHash);
    }
}
