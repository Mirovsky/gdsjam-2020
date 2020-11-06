using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput = default;

    [Space]
    [SerializeField] private float _playerSpeed;
    
    void Update()
    {
        var moveDelta = _playerInput.movementInput * (_playerSpeed * Time.deltaTime);

        transform.position = transform.position + new Vector3(moveDelta.x, moveDelta.y, 0.0f);
    }
}
