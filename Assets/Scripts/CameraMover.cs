using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private float _positionZ;

    private void Awake()
    {
        _positionZ = transform.position.z;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(_player.position.x, _player.position.y, _positionZ);
    }
}
