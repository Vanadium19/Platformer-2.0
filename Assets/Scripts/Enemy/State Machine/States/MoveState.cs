using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _layerMask;
    
    private Player _target;

    private void OnEnable()
    {              
        AnimatorController.SetRunParam(true);
    }

    private void Start()
    {
        _target = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (_target != null)
        {
            MoveToTarget();
        }
    }

    private void OnDisable()
    {
        AnimatorController.SetRunParam(false);
    }

    private void MoveToTarget()
    {
        Vector2 targetPosition = new Vector2(_target.transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

        int angle = _target.transform.position.x > transform.position.x ? ProjectData.Angles.LeftTurnAngle : ProjectData.Angles.RightTurnAngle;
        transform.localEulerAngles = new Vector3(0, angle, 0);
    }
}
