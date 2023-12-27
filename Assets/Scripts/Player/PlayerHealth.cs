using UnityEngine;

public class PlayerHealth : ObjectHealth
{
    public void Treat(float healPoint)
    {
        Health = Health + healPoint > MaxHealth ? MaxHealth : Health + healPoint;
        InvokeHealthChanged();
    }
}
