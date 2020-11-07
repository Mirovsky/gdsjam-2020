using UnityEngine;
using Zenject;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput = default;
    [SerializeField] private Rigidbody2D _rigidbody2D = default;
    
    [Space]
    [SerializeField] private float _playerSpeed;
    
    [Inject]
    private LevelArea _levelArea = default;


    void FixedUpdate()
    {
        var moveDelta = _playerInput.movementInput * (_playerSpeed * Time.deltaTime);
        var pos = _rigidbody2D.position + moveDelta;

        if (IsPositionValid(pos))
        {
            _rigidbody2D.MovePosition(pos);
        }
    }


    bool IsPositionValid(Vector2 pos)
    {
        foreach (var collider in _levelArea.Colliders)
        {
            if (collider.bounds.Contains(pos)) return true;
        }

        return false;
    }
}
