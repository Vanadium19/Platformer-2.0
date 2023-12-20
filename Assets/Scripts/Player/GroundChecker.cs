using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    private Transform _transform;
    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _isGrounded = CheckGround();
    }

    private bool CheckGround()
    {
        bool isGrounded = false;

        var collider = Physics2D.OverlapCircle(_transform.position, _radius, _layerMask);

        if (collider != null)
            isGrounded = true;        

        return isGrounded;
    }
}
