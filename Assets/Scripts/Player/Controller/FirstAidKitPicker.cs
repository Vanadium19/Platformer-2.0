using UnityEngine;

public class FirstAidKitPicker : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FirstAidKit firstAidKit))
        {
            _playerHealth.Treat(firstAidKit.HealPoint);
            Destroy(collision.gameObject);
        }
    }

}
