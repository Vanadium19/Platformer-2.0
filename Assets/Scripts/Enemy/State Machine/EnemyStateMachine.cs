using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private AbstractState _startState;

    private AbstractState _currentState;

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

    private void Reset(AbstractState startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.TurnOn(true);
    }

    private void Transit(AbstractState nextState)
    {
        if (_currentState != null)
            _currentState.TurnOn(false);

        _currentState = nextState;

        if (_currentState != null)
            _currentState.TurnOn(true);
    }
}
