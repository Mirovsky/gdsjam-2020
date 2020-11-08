using FMODUnity;
using UnityEngine;
using Zenject;

public class PlayerTruthTransfer : MonoBehaviour
{
    [SerializeField] private Collider2DEvents _collider2DEvents = default;

    [Space]
    [SerializeField] private float _transferSpeedPerSecond = default;

    [Space]
    [EventRef, SerializeField] private string _transferEventRef = default;
    
    [Inject] private TruthDataModel _truthDataModel = default;

    private TruthAgent _currentTruthAgent;

    private FMOD.Studio.EventInstance _transferEventInstance = default;
    
    private void Start()
    {
        _collider2DEvents.onTriggerEnter += HandleCollider2DEventsOnTriggerEnter;
        _collider2DEvents.onTriggerExit += HandleCollider2DEventsOnTriggerExit;

        var eventDescription = RuntimeManager.GetEventDescription(_transferEventRef);
        eventDescription.createInstance(out _transferEventInstance);
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
        var currentTruth = _truthDataModel.GetNormalizedTruthFrom(_currentTruthAgent.truthAmount);
        
        _transferEventInstance.setParameterByName("instancedTruth", currentTruth);
    }
    
    private void HandleCollider2DEventsOnTriggerEnter(Collider2D col)
    {
        var truthAgent = col.GetComponent<TruthAgent>();
        if (truthAgent == null)
        {
            return;
        }

        _currentTruthAgent = truthAgent;
        _transferEventInstance.start();
    }

    private void HandleCollider2DEventsOnTriggerExit(Collider2D col)
    {
        var truthAgent = col.GetComponent<TruthAgent>();
        if (truthAgent == null)
        {
            return;
        }

        _currentTruthAgent = null;
        _transferEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        _transferEventInstance.setParameterByName("instancedTruth", 0.0f);
    }
}
