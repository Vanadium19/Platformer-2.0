using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AbstractAnimator))]
public abstract class AbstractHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _deathDelay;

    protected float Health;
    private AbstractAnimator _abstractAnimator;

    public event UnityAction<float> HealthChanged;
    public event UnityAction Died;

    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _abstractAnimator = GetComponent<AbstractAnimator>();
        Health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0)
            return;

        if (Health <= 0)
            return;

        Health -= damage;        

        if (Health <= 0)
        {
            Health = 0;            
            Die();
        }
        else
        {
            _abstractAnimator.SetTrigger(ProjectData.AnimatorTriggers.TakeHitHash);
            InvokeHealthChanged();
        }

    }

    protected void InvokeHealthChanged()
    {
        HealthChanged?.Invoke(Health);
    }

    private void Die()
    {
        Died?.Invoke();
        _abstractAnimator.SetTrigger(ProjectData.AnimatorTriggers.DeathHash);
        Destroy(gameObject, _deathDelay);
    }
}