using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FirstAidKit firstAidKit))
        {
            _player.Treat(firstAidKit.HealPoint);
            Destroy(collision.gameObject);
        }
    }

}
