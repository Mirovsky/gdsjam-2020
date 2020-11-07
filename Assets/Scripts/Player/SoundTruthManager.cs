using UnityEngine;
using Zenject;

public class SoundTruthManager : MonoBehaviour
{
    [FMODUnity.ParamRef, SerializeField] private string _truthAmountParameterRef;

    [Inject] private TruthDataModel _truthDataModel = default;

    protected void Update()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName(_truthAmountParameterRef,
            _truthDataModel.GetNormalizedCurrentTruth());
    }
}
