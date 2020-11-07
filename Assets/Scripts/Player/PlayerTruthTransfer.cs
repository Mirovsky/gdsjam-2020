using UnityEngine;
using Zenject;

public class PlayerTruthTransfer : MonoBehaviour
{
    [SerializeField] private Collider2DEvents _collider2DEvents = default;
    
    [Inject] private TruthDataModel _truthDataModel = default;
    
    void Start()
    {
        _collider2DEvents.onTriggerEnter += HandleCollider2DEventsOnTriggerEnter;
    }

    private void OnDestroy()
    {
        if (_collider2DEvents != null)
        {
            _collider2DEvents.onTriggerEnter -= HandleCollider2DEventsOnTriggerEnter;
        }   
    }

    private void HandleCollider2DEventsOnTriggerEnter(Collider2D col)
    {
        var truthAgent = col.GetComponent<TruthAgent>();

        // Only transfer truth to agents that don't have it already
        if (truthAgent == null || truthAgent.hasTruth)
        {
            return;
        }
        
        truthAgent.SetTruth(_truthDataModel.GetCurrentTruth());
    }
}
