using UnityEngine;

[RequireComponent(typeof(AnimatorController))]
public class SimpleAttack : MonoBehaviour
{
    [SerializeField] private float _damage = 5f;

    private AnimatorController _playerAnimatorController;

    private void Awake()
    {
        _playerAnimatorController = GetComponent<AnimatorController>();
    }

    public void Attack(Enemy enemy)
    {
        _playerAnimatorController.SetTrigger(ProjectData.AnimatorTriggers.AttackHash);

        if (enemy != null)
            enemy.TakeDamage(_damage);
    }
}
