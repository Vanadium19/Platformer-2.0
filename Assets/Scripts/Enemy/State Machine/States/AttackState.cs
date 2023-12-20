using UnityEngine;

public class AttackState : AbstractState
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private float _range;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _layerMask;

    private float _elapsedTime;    

    private void Update()
    {
        if (_elapsedTime <= 0)
        {
            Attack();
            _elapsedTime = _delay;
        }

        _elapsedTime -= Time.deltaTime;
    }

    private void Attack()
    {
        StateAnimator.SetTrigger(ProjectData.AnimatorTriggers.AttackHash);

        var collider = Physics2D.OverlapCircle(_attackPoint.position, _range, _layerMask);

        if (collider != null)
        {
            if (collider.TryGetComponent(out Player player))
                player.TakeDamage(_damage);
        }
    }
}
