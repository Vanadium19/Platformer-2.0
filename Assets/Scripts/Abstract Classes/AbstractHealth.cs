using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AbstractAnimator))]
public abstract class AbstractHealth : MonoBehaviour
{
    [SerializeField] protected float Health;
    [SerializeField] private float _deathDelay;

    private AbstractAnimator _abstractAnimator;

    public event UnityAction<float> HealthChanged;
    public event UnityAction Died;

    private void Awake()
    {
        _abstractAnimator = GetComponent<AbstractAnimator>();
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
            Died?.Invoke();
            Die();
        }
        else
        {
            HealthChanged?.Invoke(Health);
            _abstractAnimator.SetTrigger(ProjectData.AnimatorTriggers.TakeHitHash);
        }

    }

    private void Die()
    {
        Destroy(gameObject, _deathDelay);
        _abstractAnimator.SetTrigger(ProjectData.AnimatorTriggers.DeathHash);
    }
}