using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private State _currentState;
    private bool _isStopped = false; 

    private void Start()
    {
        Reset(_startState);
    }

    private void Update()
    {
        if (_isStopped)
            return;

        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);

    }

    public void TurnOn(bool value)
    {
        _isStopped = !value;
        _currentState.TurnOn(value);
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
