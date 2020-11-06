using UnityEngine;
using Zenject;

public class TruthDataModel : MonoBehaviour
{
    [SerializeField] private float _truthAmount = default;
    
    [Inject] TruthDataSO _truthData = default;

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
}
