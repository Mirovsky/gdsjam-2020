using FMODUnity;
using UnityEngine;
using Zenject;

public class SoundTruthManager : MonoBehaviour
{
    [ParamRef, SerializeField] private string _truthAmountParameterRef = default;

    [Space]
    [EventRef, SerializeField] private string _ambienceEventRef = default;
    [EventRef, SerializeField] private string _dirtEventRef = default;
    
    [Inject] private TruthDataModel _truthDataModel = default;
    [Inject] private GameManager _gameManager;

    private FMOD.Studio.EventInstance _ambienceEventInstance = default;
    private FMOD.Studio.EventInstance _dirtEventInstance = default;
    
    protected void Start()
    {
        _gameManager.levelStartEvent += HandleGameManagerLevelStart;
        _gameManager.levelFinishedEvent += HandleGameManagerLevelFinished;
    }

    protected void OnDestroy()
    {
        if (_gameManager != null)
        {
            _gameManager.levelStartEvent -= HandleGameManagerLevelStart;
            _gameManager.levelFinishedEvent -= HandleGameManagerLevelFinished;
        }
    }

    private void HandleGameManagerLevelStart()
    {
        var eventDescription = RuntimeManager.GetEventDescription(_ambienceEventRef);
        eventDescription.createInstance(out _ambienceEventInstance);
        
        _ambienceEventInstance.start();

        eventDescription = RuntimeManager.GetEventDescription(_dirtEventRef);
        eventDescription.createInstance(out _dirtEventInstance);

        _dirtEventInstance.start();

        RuntimeManager.StudioSystem.setParameterByName(_truthAmountParameterRef,
            _truthDataModel.GetNormalizedCurrentTruth());
    }

    private void HandleGameManagerLevelFinished()
    {
        _ambienceEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        _dirtEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    protected void Update()
    {
        var truth = _truthDataModel.GetNormalizedCurrentTruth();
        RuntimeManager.StudioSystem.setParameterByName(_truthAmountParameterRef, truth);
    }
}
