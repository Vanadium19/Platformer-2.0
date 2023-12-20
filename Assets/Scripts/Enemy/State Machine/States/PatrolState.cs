using System.Collections;
using UnityEngine;

public class PatrolState : AbstractState
{
    [SerializeField] private float _finalPositionX;
    [SerializeField] private float _speed;

    private Vector3 _startPosition;
    private Vector3 _finalPosition;
    private Vector3 _targetPosition;
    private Coroutine _moving;

    private void OnEnable()
    {
        if (_startPosition == _finalPosition)
            SetPositions();

        SetTargetPosition();
        _moving = StartCoroutine(Move());
        StateAnimator.SetRunParam(true);
    }

    private void OnDisable()
    {
        StopCoroutine(_moving);
        StateAnimator.SetRunParam(false);
    }
    
    private void SetPositions()
    {
        _startPosition = transform.position;
        _finalPosition = new Vector2(_finalPositionX, transform.position.y);
    }

    private void SetTargetPosition()
    {
        _targetPosition = transform.position.x == _startPosition.x ? _finalPosition : _startPosition;
        int angle = _targetPosition.x > transform.position.x ? ProjectData.Angles.LeftTurnAngle : ProjectData.Angles.RightTurnAngle;
        transform.localEulerAngles = new Vector3(0, angle, 0);
    }

    private IEnumerator Move()
    {
        while (true)
        {
            if (transform.position.x == _targetPosition.x)
                SetTargetPosition();            

            while (transform.position.x != _targetPosition.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, 
                    new Vector2(_targetPosition.x, transform.position.y), _speed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
