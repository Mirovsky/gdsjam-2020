using UnityEngine;
using Zenject;

public class TruthAgent : MonoBehaviour
{
    [SerializeField] private float _truthAmount = default;

    [Inject] private TruthDataModel _truthDataModel = default;
    
    public event System.Action<float> truthUpdatedEvent;
    
    public void UpdateTruthBy(float amount)
    {
        _truthAmount = Mathf.Clamp(_truthAmount + amount, 0.0f, _truthDataModel.GetMaxTruth());
        
        truthUpdatedEvent?.Invoke(_truthAmount);
    }
}
