using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AbstractAnimator : MonoBehaviour
{
    protected Animator Animator;
    protected bool IsRunning;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    public void SetRunParam(bool isRunning)
    {
        IsRunning = isRunning;
    }

    public void SetTrigger(int triggerHash)
    {
        Animator.SetTrigger(triggerHash);
    }
}
