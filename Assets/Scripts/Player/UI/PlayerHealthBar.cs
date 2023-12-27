using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthBarChanger))]
public class PlayerHealthBar : HealthBar
{
    private HealthBarChanger _healthBarChanger;

    private void Awake()
    {
        _healthBarChanger = GetComponent<HealthBarChanger>();
        _healthBarChanger.Initialization(BarImage, TargetHealth.MaxHealth);
    }

    protected override void OnTargetDied()
    {
        BarImage.fillAmount = 0;
    }

    protected override void OnHealthChanged(float health)
    {
        _healthBarChanger.ChangeHealth(health);
    }  
}
