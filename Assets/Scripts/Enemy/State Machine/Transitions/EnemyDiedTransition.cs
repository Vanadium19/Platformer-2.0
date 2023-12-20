using UnityEngine;

[RequireComponent(typeof(AbstractHealth))]
public class EnemyDiedTransition : AbstractTransition
{
    private AbstractHealth _abstractHealth;

    private void Awake()
    {
        _abstractHealth = GetComponent<AbstractHealth>();

    }

    private void OnEnable()
    {
        NeedTransit = false;
        _abstractHealth.Died += OnEnemyDied;
    }

    private void OnDisable()
    {
        _abstractHealth.Died -= OnEnemyDied;
    }

    private void OnEnemyDied()
    {
        NeedTransit = true;
    }
}
