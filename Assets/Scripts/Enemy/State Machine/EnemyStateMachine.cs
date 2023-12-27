using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private State _currentState;

    private void Start()
    {
        Reset(_startState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);

    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.TurnOn(true);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.TurnOn(false);

        _currentState = nextState;

        if (_currentState != null)
            _currentState.TurnOn(true);
    }
}
