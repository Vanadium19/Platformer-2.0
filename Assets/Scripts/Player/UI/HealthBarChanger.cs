using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarChanger : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Coroutine _healthChanging;
    private Image _barImage;
    private float _maxHealth;

    public void Initialization(Image barImage, float maxHealth)
    {
        _barImage = barImage;
        _maxHealth = maxHealth;
    }

    public void ChangeHealth(float health)
    {
        StopHealthChanging();
        StartHealthChanging(health);
    }

    private void StartHealthChanging(float health)
    {
        _healthChanging = StartCoroutine(ChangeHealthTo(health));
    }

    private void StopHealthChanging()
    {
        if (_healthChanging != null)
            StopCoroutine(_healthChanging);
    }

    private IEnumerator ChangeHealthTo(float health)
    {
        float targetValue = health / _maxHealth;

        while (_barImage.fillAmount != targetValue)
        {
            _barImage.fillAmount = Mathf.MoveTowards(_barImage.fillAmount, targetValue, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
