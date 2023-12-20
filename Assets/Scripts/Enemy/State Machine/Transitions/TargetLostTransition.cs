using UnityEngine;

public class TargetLostTransition : AbstractTransition
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            NeedTransit = true;
    }
}
