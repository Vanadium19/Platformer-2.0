using UnityEngine;

public class EnemyProvokedTransition : Transition
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            NeedTransit = true;
    }
}
