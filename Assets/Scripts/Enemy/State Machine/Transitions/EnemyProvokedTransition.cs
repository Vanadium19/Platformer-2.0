using UnityEngine;

public class EnemyProvokedTransition : AbstractTransition
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            NeedTransit = true;
    }
}
