using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStepsController : MonoBehaviour
{
    [FMODUnity.EventRef, SerializeField] private string _stepEventRef = default;

    private int _triggeredFrame = -1;
    
    // Triggered by animation
    public void Step()
    {
        if (_triggeredFrame == Time.frameCount)
        {
            return;
        }
        _triggeredFrame = Time.frameCount;
        
        FMODUnity.RuntimeManager.PlayOneShot(_stepEventRef);
    }
}
