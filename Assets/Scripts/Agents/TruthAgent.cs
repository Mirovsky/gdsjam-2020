using UnityEngine;

public class TruthAgent : MonoBehaviour
{
    [SerializeField] private bool _hasTruth = default;
    [SerializeField] private float _truthAmount = default;

    public event System.Action<float> truthSetEvent;
    
    public bool hasTruth => _hasTruth;
    
    public void SetTruth(float truthAmount)
    {
        _hasTruth = true;
        _truthAmount = truthAmount;
        
        truthSetEvent?.Invoke(_truthAmount);
    }
}
