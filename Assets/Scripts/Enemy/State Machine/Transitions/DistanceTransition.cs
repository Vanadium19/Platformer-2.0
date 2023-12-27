using UnityEngine;

public class DistanceTransition : Transition
{    
    [SerializeField] private float _targetDistance;

    private Player _target;

    private void Start()
    {        
        _target = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (_target == null)
            return;

        if (Vector2.Distance(transform.position, _target.transform.position) < _targetDistance)
            NeedTransit = true;        
    }
}
