using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _range;
    [SerializeField] private float _delay;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _layerMask;

    private bool _isAttacking;
    private PlayerAnimator _playerAnimator;
    private Coroutine _attacking;

    public bool IsAttacking => _isAttacking;

    private void Awake()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    public void StartAttack()
    {
        if (_attacking != null)
            StopCoroutine(_attacking);

        _attacking = StartCoroutine(StartAttacking());
    }

    private IEnumerator StartAttacking()
    {
        _isAttacking = true;
        Attack();
        yield return new WaitForSeconds(_delay);
        _isAttacking = false;
    }

    private void Attack()
    {
        _playerAnimator.SetTrigger(ProjectData.AnimatorTriggers.AttackHash);

        var collider = Physics2D.OverlapCircle(_attackPoint.position, _range, _layerMask);

        if (collider != null)
        {      
            if (collider.TryGetComponent(out Enemy enemy))            
                enemy.TakeDamage(_damage);            
        }
    }
}
