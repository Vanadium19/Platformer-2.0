using UnityEngine;

public class IdleState : AbstractState
{
    private void OnEnable()
    {
        StateAnimator.SetRunParam(false);
    }
}
