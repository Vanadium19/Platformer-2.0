using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(AnimatorController))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _duration = 6f;
    [SerializeField] private float _damage = 0.1f;
    [SerializeField] private float _range = 0.75f;
    [SerializeField] private float _step = 0.1f;

    private Enemy _targetEnemy;
    private PlayerHealth _playerHealth;
    private AnimatorController _playerAnimatorController;
    private float _elapsedTime;
    private Coroutine _vampirising;
    private bool _isVampirising;


    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerAnimatorController = GetComponent<AnimatorController>();
    }

    private void Update()
    {
        if (_isVampirising == false)
            return;

        if (_targetEnemy == null || CalculateDistance(_targetEnemy.transform) > _range)
            StopVampirising(_targetEnemy);
    }

    public void Employ(Enemy enemy)
    {
        if (enemy == null)
            return;

        if (_vampirising != null)
        {
            StopCoroutine(_vampirising);
            StopVampirising(_targetEnemy);
        }

        _vampirising = StartCoroutine(UseAbility(enemy));
    }

    private IEnumerator UseAbility(Enemy enemy)
    {
        WaitForSeconds delay = new WaitForSeconds(_step);

        StartVampirising(enemy);

        while (_elapsedTime < _duration)
        {
            _elapsedTime += _step;
            enemy.TakeDamage(_damage, false);            
            _playerHealth.Treat(_damage);
            yield return delay;
        }

        StopVampirising(enemy);
    }

    private void StartVampirising(Enemy enemy)
    {
        _elapsedTime = 0;
        _targetEnemy = enemy;
        _isVampirising = true;
        _playerAnimatorController.SetTrigger(ProjectData.AnimatorTriggers.VampirismHash);
        _playerAnimatorController.SetBoolParam(ProjectData.AnimatorParams.VampirizableStateHash, true);
        VampirizeEnemy(enemy, true);
    }

    private void StopVampirising(Enemy enemy)
    {
        _isVampirising = false;
        _playerAnimatorController.SetBoolParam(ProjectData.AnimatorParams.VampirizableStateHash, false);

        if (enemy != null)
            VampirizeEnemy(enemy, false);
    }

    private static void VampirizeEnemy(Enemy enemy, bool value)
    {
        if (enemy.TryGetComponent(out Vampirizable vampirizable))
            vampirizable.enabled = value;
    }

    private float CalculateDistance(Transform enemy)
    {
        return (enemy.position - transform.position).magnitude;
    }
}
