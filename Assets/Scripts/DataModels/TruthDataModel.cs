using UnityEngine;

public class TruthDataModel : MonoBehaviour
{
    [SerializeField] private TruthDataSO _truthData = default;
    
    [Space]
    [SerializeField, Range(0, 100)] private float _truthAmount = default;

    void Start()
    {
        _truthAmount = _truthData.defaultTruthAmount;
    }
    
    public void ReduceTruthBy(float reduceMult)
    {
        _truthAmount *= _truthData.baseTruthReducePerSecond * reduceMult * Time.deltaTime;
    }

    public float GetCurrentTruth()
    {
        return _truthAmount;
    }

    public float GetMaxTruth()
    {
        return _truthData.defaultTruthAmount;
    }

    public float GetNormalizedCurrentTruth()
    {
        return _truthAmount / _truthData.defaultTruthAmount;
    }
}
