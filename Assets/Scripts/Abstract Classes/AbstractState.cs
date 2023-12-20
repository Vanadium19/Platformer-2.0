using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AbstractAnimator))]
public abstract class AbstractState : MonoBehaviour
{   
    [SerializeField] private List<AbstractTransition> _transitions;
        
    private AbstractAnimator _abstractAnimator;

    protected AbstractAnimator StateAnimator => _abstractAnimator;

    private void Awake()
    {
        _abstractAnimator = GetComponent<AbstractAnimator>();;
    }

    public void TurnOn(bool isTurnOn)
    {
        if (enabled == !isTurnOn)
        {
            enabled = isTurnOn;

            foreach (var transition in _transitions)
                transition.enabled = isTurnOn;
        }
    }

    public AbstractState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)            
                return transition.TargetState;                        
        }

        return null;
    }
}
