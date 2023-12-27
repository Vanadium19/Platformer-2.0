using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected ObjectHealth TargetHealth;
    [SerializeField] protected Image BarImage;

    private void OnEnable()
    {
        TargetHealth.HealthChanged += OnHealthChanged;
        TargetHealth.Died += OnTargetDied;
    }

    private void OnDisable()
    {
        TargetHealth.HealthChanged -= OnHealthChanged;
        TargetHealth.Died -= OnTargetDied;
    }

    protected abstract void OnHealthChanged(float health);
    
    protected abstract void OnTargetDied();    
}
