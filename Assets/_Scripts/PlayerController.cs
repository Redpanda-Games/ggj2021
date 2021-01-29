using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Rigidbody2D _rb;
    private MultiPlayerControls _playerControls;
    
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
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

    public void OnMove(InputValue value)
    {
        // Vector2 input = value.Get<Vector2>();
        // input *= speed * Time.fixedDeltaTime;
        // _rb.MovePosition(_rb.position + input);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 input = _playerControls.Player.Move.ReadValue<Vector2>();
        input *= speed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + input);
    }
}
