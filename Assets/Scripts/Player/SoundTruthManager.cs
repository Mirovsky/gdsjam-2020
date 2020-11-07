using System;
using FMODUnity;
using UnityEngine;
using Zenject;

public class SoundTruthManager : MonoBehaviour
{
    [ParamRef, SerializeField] private string _truthAmountParameterRef = default;

    [Space]
    [EventRef, SerializeField] private string _ambienceEventRef = default;
    
    [Inject] private TruthDataModel _truthDataModel = default;
    [Inject] private GameManager _gameManager;

    private FMOD.Studio.EventInstance _eventInstance = default;
    
    protected void Start()
    {
        _gameManager.levelStartEvent += HandleGameManagerLevelStart;
    }

    protected void OnDestroy()
    {
        if (_gameManager != null)
        {
            _gameManager.levelStartEvent -= HandleGameManagerLevelStart;
        }
    }

    private void HandleGameManagerLevelStart()
    {
        var eventDescription = RuntimeManager.GetEventDescription(_ambienceEventRef);
        eventDescription.createInstance(out _eventInstance);

        _eventInstance.start();
    }

    protected void Update()
    {
        RuntimeManager.StudioSystem.setParameterByName(_truthAmountParameterRef,
            _truthDataModel.GetNormalizedCurrentTruth());
    }
}
