using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Rigidbody2D _rb;
    private Animator _animator;
    private MultiPlayerControls _playerControls;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _playerControls = new MultiPlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }
    private void OnDisable()
    {
        _playerControls.Disable();
    }
    
    void FixedUpdate()
    {
        Vector2 input = _playerControls.Player.Move.ReadValue<Vector2>();
        input *= speed * Time.fixedDeltaTime;
        
        _animator.SetFloat("Horizontal", input.x);
        _animator.SetFloat("Vertical", input.y);
        
        _rb.MovePosition(_rb.position + input);
    }
}
