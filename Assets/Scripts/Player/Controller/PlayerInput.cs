using UnityEngine;

[RequireComponent(typeof(PlayerAttacker))]
public class PlayerInput : MonoBehaviour
{    
    private Vector2 _moveInput;
    private bool _isJumped = false;
    private PlayerAttacker _playerAttacker;

    public Vector2 Control => _moveInput;
    public bool IsJumped => _isJumped;

    private void Awake()
    {
        _playerAttacker = GetComponent<PlayerAttacker>();
    }

    private void Update()
    {
        _isJumped = false;

        _moveInput = Vector2.right * Input.GetAxis(ProjectData.Axes.Horizontal);

        if (Input.GetKeyDown(KeyCode.Space))        
            _isJumped = true;

        if (Input.GetKeyDown(KeyCode.Mouse0) && _playerAttacker.IsAttacking == false)
            _playerAttacker.StartAttack();

        if (Input.GetKeyDown(KeyCode.LeftShift))
            _playerAttacker.UseVampirism();
    }
}
