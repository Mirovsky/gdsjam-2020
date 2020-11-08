using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruthAgentAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator = default;
    [SerializeField] private MoveAlongPath _moveAlongPath = default;

    private int xAnimatorId;
    private int yAnimatorId;
    private int absSpeedAnimatorId;

    protected void Start()
    {
        xAnimatorId = Animator.StringToHash("X");
        yAnimatorId = Animator.StringToHash("Y");
        absSpeedAnimatorId = Animator.StringToHash("AbsSpeed");
    }
    

    // Update is called once per frame
    void Update()
    {
        var dir = _moveAlongPath.direction;
        
        _animator.SetFloat(xAnimatorId, dir.x);
        _animator.SetFloat(yAnimatorId, dir.y);
        _animator.SetFloat(absSpeedAnimatorId, dir.magnitude);
    }
}
