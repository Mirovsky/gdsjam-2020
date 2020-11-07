using UnityEngine;
using Zenject;

public class PlayerTruthTransfer : MonoBehaviour
{
    [SerializeField] private Collider2DEvents _collider2DEvents = default;

    [Space]
    [SerializeField] private float _transferSpeedPerSecond = default;
    
    [Inject] private TruthDataModel _truthDataModel = default;

    private TruthAgent _currentTruthAgent;
    
    
    private void Start()
    {
        _collider2DEvents.onTriggerEnter += HandleCollider2DEventsOnTriggerEnter;
        _collider2DEvents.onTriggerExit += HandleCollider2DEventsOnTriggerExit;
    }

    private void OnDestroy()
    {
        if (_collider2DEvents != null)
        {
            _collider2DEvents.onTriggerEnter -= HandleCollider2DEventsOnTriggerEnter;
            _collider2DEvents.onTriggerExit -= HandleCollider2DEventsOnTriggerExit;
        }   
    }

    private void Update()
    {
        if (_currentTruthAgent == null)
        {
            return;
        }

        _currentTruthAgent.UpdateTruthBy(_transferSpeedPerSecond * Time.deltaTime);
    }
    
    private void HandleCollider2DEventsOnTriggerEnter(Collider2D col)
    {
        var truthAgent = col.GetComponent<TruthAgent>();
        if (truthAgent == null)
        {
            return;
        }

        _currentTruthAgent = truthAgent;
    }

    private void HandleCollider2DEventsOnTriggerExit(Collider2D col)
    {
        var truthAgent = col.GetComponent<TruthAgent>();
        if (truthAgent == null)
        {
            return;
        }

        _currentTruthAgent = null;
    }
}
