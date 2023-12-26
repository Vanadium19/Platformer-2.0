using UnityEngine;

public class EnemyHealthBar : AbstractHealthBar
{
    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponentInParent<Canvas>();
        
        if (_canvas != null)
            _canvas.worldCamera = Camera.main;
    }

    protected override void OnHealthChanged(float health)
    {
        BarImage.fillAmount = health / TargetHealth.MaxHealth;
    }

    protected override void OnTargetDied()
    {
        BarImage.enabled = false;
    }
}
