using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SimpleAttack))]
[RequireComponent(typeof(Vampirism))]
public class PlayerAttacker : MonoBehaviour
{    
    [SerializeField] private float _range;
    [SerializeField] private float _delay;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _layerMask;

    private bool _isAttacking;   
    private Coroutine _attacking;

    private SimpleAttack _simpleAttack;
    private Vampirism _vampirism;

    public bool IsAttacking => _isAttacking;

    private void Awake()
    {
        _simpleAttack = GetComponent<SimpleAttack>();
        _vampirism = GetComponent<Vampirism>();
    }

    public void StartAttack()
    {
        if (_attacking != null)
            StopCoroutine(_attacking);

        _attacking = StartCoroutine(StartAttacking());
    }

    public void UseVampirism()
    {
        _vampirism.Employ(TryGetEnemy());
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
        _simpleAttack.Attack(TryGetEnemy());
    }

    private Enemy TryGetEnemy()
    {
        var collider = Physics2D.OverlapCircle(_attackPoint.position, _range, _layerMask);

        if (collider != null)
        {
            if (collider.TryGetComponent(out Enemy enemy))
                return enemy;
        }

        return null;
    }
}
