using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput = default;
    [SerializeField] private Rigidbody2D _rigidbody2D = default;
    
    [Space]
    [SerializeField] private float _playerSpeed;
    
    void FixedUpdate()
    {
        var moveDelta = _playerInput.movementInput * (_playerSpeed * Time.deltaTime);

        _rigidbody2D.MovePosition(_rigidbody2D.position + moveDelta);
    }
}
