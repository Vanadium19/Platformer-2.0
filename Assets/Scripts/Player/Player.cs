using UnityEngine;

public class Player : AbstractHealth
{
    public void Treat(float healPoint)
    {
        Health += healPoint;
    }
}
