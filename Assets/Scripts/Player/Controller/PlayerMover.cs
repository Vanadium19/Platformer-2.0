using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AnimatorController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private GroundChecker _groundChecker;
    
    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;
    private AnimatorController _playerAnimatorController;

    private bool _isGrounded;
    private bool _isOldGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = gameObject.AddComponent<PlayerInput>();
        _playerAnimatorController = GetComponent<AnimatorController>();
    }

    private void Update()
    {
        _isGrounded = _groundChecker.IsGrounded;
        
        Move(_playerInput.Control, _playerInput.IsJumped);

        _isOldGrounded = _isGrounded;
    }

    private void Move(Vector2 input, bool isJumped)
    {
        MoveHorizontally(input);
        Jump(isJumped);
    }

    private void MoveHorizontally(Vector2 input)
    {
        Vector2 velocity = _speed * input + _rigidbody.velocity.y * Vector2.up;

        Flip(velocity.x);
        _rigidbody.velocity = velocity;        
        _playerAnimatorController.SetBoolParam(ProjectData.AnimatorParams.RunStateHash, velocity.x != 0 && _isGrounded);
    }

    private void Flip(float velocityX)
    {
        if (velocityX != 0)
        {
            int horizontalAngle = velocityX < 0 ? ProjectData.Angles.RightTurnAngle : ProjectData.Angles.LeftTurnAngle;
            transform.localEulerAngles = new Vector2(0, horizontalAngle);
        }
    }

    private void Jump(bool isJumped)
    {
        if (isJumped && _isGrounded)
        {
            _rigidbody.AddForce(_jumpForce * Vector2.up, ForceMode2D.Impulse);
            _playerAnimatorController.SetTrigger(ProjectData.AnimatorTriggers.JumpHash);
        }

        if (_isGrounded && _isOldGrounded == false && _rigidbody.velocity.y <= 0)                    
            _playerAnimatorController.SetTrigger(ProjectData.AnimatorTriggers.LandHash);        
    }
}
