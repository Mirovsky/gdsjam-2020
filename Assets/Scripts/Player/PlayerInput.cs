using UnityEngine;


public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float smoothTime;
    
    public Vector2 movementInput { get; private set; }
    
    private PlayerInputActions _playerInputActions;
    private Vector2 _inputVelocity;
    
    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
    }
    
    private void OnEnable()
    {
        _playerInputActions.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Disable();
    }

    void Update()
    {
        var target = _playerInputActions.Player.Movement.ReadValue<Vector2>();

        var x = Mathf.SmoothDamp(movementInput.x, target.x, ref _inputVelocity.x, smoothTime);
        var y = Mathf.SmoothDamp(movementInput.y, target.y, ref _inputVelocity.y, smoothTime);
        
        movementInput = new Vector2(x, y);
    }
}
