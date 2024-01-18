using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimatorController))]
public abstract class State : MonoBehaviour
{   
    [SerializeField] private List<Transition> _transitions;        

    protected AnimatorController EnemyAnimatorController { get; private set; }   

    private void Awake()
    {
        EnemyAnimatorController = GetComponent<AnimatorController>();;
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

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)            
                return transition.TargetState;                        
        }

        return null;
    }
}
