using UnityEngine;

public class TargetRanAwayTransition : AbstractTransition
{
    [SerializeField] private float _range;

    private Player _target;

    private void Start()
    {
        _target = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (_target == null)
            return;

        if (Vector2.Distance(transform.position, _target.transform.position) > _range)
            NeedTransit = true;
    }
}
