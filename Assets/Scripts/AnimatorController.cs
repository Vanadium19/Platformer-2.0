using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetBoolParam(int boolHash, bool value)
    {
        _animator.SetBool(boolHash, value);
    }

    public void SetBoolParam(string boolName, bool value)
    {
        _animator.SetBool(boolName, value);
    }

    public void SetTrigger(int triggerHash)
    {
        _animator.SetTrigger(triggerHash);
    }
}
