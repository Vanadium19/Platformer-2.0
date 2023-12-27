using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private float _healPoint;

    public float HealPoint => _healPoint;
}
