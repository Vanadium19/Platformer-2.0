using UnityEngine;

public class IdleState : State
{
    private void OnEnable()
    {
        AnimatorController.SetRunParam(false);
    }
}
