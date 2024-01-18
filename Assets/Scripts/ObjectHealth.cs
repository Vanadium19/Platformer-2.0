using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AnimatorController))]
public abstract class ObjectHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _deathDelay;

    protected float Health;
    private AnimatorController _abstractAnimator;

    public event UnityAction<float> HealthChanged;
    public event UnityAction Died;

    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _abstractAnimator = GetComponent<AnimatorController>();
        Health = _maxHealth;
    }

    public void TakeDamage(float damage, bool isPlayAnimation = true)
    {
        if (damage <= 0)
            return;

        if (Health <= 0)
            return;

        ApplyDamage(damage, isPlayAnimation);
    }

    protected void InvokeHealthChanged()
    {
        HealthChanged?.Invoke(Health);
    }

    private void ApplyDamage(float damage, bool isPlayAnimation)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
        else
        {
            if (isPlayAnimation)
                _abstractAnimator.SetTrigger(ProjectData.AnimatorTriggers.TakeHitHash);

            InvokeHealthChanged();
        }
    }

    private void Die()
    {
        Died?.Invoke();
        _abstractAnimator.SetTrigger(ProjectData.AnimatorTriggers.DeathHash);
        Destroy(gameObject, _deathDelay);
    }
}