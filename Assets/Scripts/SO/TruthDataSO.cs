using UnityEngine;

[CreateAssetMenu(menuName = "SO/TruthDataSO")]
public class TruthDataSO : ScriptableObject
{
    [SerializeField] private float _defaultTruthAmount = default;
    
    [Space]
    [SerializeField] private float _baseTruthReducePerSecond = default;
    
    public float defaultTruthAmount => _defaultTruthAmount;
    public float baseTruthReducePerSecond => _baseTruthReducePerSecond;
}
