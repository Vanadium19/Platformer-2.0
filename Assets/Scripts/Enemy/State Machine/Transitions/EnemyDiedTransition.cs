using UnityEngine;

[RequireComponent(typeof(ObjectHealth))]
public class EnemyDiedTransition : Transition
{
    private ObjectHealth _enemyHealth;

    private void Awake()
    {
        _enemyHealth = GetComponent<ObjectHealth>();

    }

    private void OnEnable()
    {
        NeedTransit = false;
        _enemyHealth.Died += OnEnemyDied;
    }

    private void OnDisable()
    {
        _enemyHealth.Died -= OnEnemyDied;
    }

    private void OnEnemyDied()
    {
        NeedTransit = true;
    }
}
