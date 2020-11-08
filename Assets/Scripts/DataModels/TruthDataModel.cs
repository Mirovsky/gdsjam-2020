using UnityEngine;
using Zenject;

public class TruthDataModel : MonoBehaviour
{
    [SerializeField] private TruthDataSO _truthData = default;
    
    [Space]
    [SerializeField, Range(0, 100)] private float _truthAmount = default;

    [Inject] private GameManager _gameManager = default;
    
    void Start()
    {
        _truthAmount = _truthData.defaultTruthAmount;
    }
    
    public void ReduceTruthBy(float reduceMult)
    {
        _truthAmount -= _truthData.baseTruthReducePerSecond * reduceMult * Time.deltaTime;

        _truthAmount = Mathf.Clamp(_truthAmount, 0.0f, _truthData.defaultTruthAmount);

        if (_truthAmount <= 0.0f)
        {
            _gameManager.GameOver();
        }
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
        return GetNormalizedTruthFrom(_truthAmount);
    }

    public float GetNormalizedTruthFrom(float truth)
    {
        return truth / _truthData.defaultTruthAmount;
    }
}
