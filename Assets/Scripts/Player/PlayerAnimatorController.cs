using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator = default;
    [SerializeField] private PlayerInput _playerInput = default;

    private int xAnimatorId;
    private int yAnimatorId;

    protected void Start()
    {
        xAnimatorId = Animator.StringToHash("X");
        yAnimatorId = Animator.StringToHash("Y");
    }
    
    protected void Update()
    {
        var input = _playerInput.movementInput;
        _animator.SetFloat(xAnimatorId, input.x);
        _animator.SetFloat(yAnimatorId, input.y);
    }
}
