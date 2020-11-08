using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator = default;
    [SerializeField] private PlayerInput _playerInput = default;

    private int xAnimatorId;
    private int yAnimatorId;
    private int absSpeedAnimatorId;

    protected void Start()
    {
        xAnimatorId = Animator.StringToHash("X");
        yAnimatorId = Animator.StringToHash("Y");
        absSpeedAnimatorId = Animator.StringToHash("AbsSpeed");
    }
    
    protected void FixedUpdate()
    {
        var input = _playerInput.movementInput;
        _animator.SetFloat(xAnimatorId, input.x);
        _animator.SetFloat(yAnimatorId, input.y);
        _animator.SetFloat(absSpeedAnimatorId, input.magnitude);
    }
}
