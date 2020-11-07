using UnityEngine;


[CreateAssetMenu(fileName = "SoundSenseSettings", menuName = "ScriptableObjects/SoundSenseSettings", order = 1)]
public class SoundSenseSettings : ScriptableObject
{
    [Range(0.0f, 10.0f)]
    public float Sensitivity = 5;
    
    [Range(0.0f, 1.0f)]
    public float SensitivityGradientRange = 0.5f;

    public AnimationCurve SensitivityGradientFunction;
}
