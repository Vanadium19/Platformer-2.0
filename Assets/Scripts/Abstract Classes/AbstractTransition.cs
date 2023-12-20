using UnityEngine;

public abstract class AbstractTransition : MonoBehaviour
{
    [SerializeField] private AbstractState _targetState;

    public AbstractState TargetState => _targetState;
    public bool NeedTransit { get; protected set; } 

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
