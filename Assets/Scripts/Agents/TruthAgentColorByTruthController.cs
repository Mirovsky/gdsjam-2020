using UnityEngine;
using Zenject;

[RequireComponent(typeof(TruthAgent))]
public class TruthAgentColorByTruthController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer = default;

    [Space]
    [SerializeField] private Color _defaultColor = Color.gray;
    [SerializeField] private Color _noTruthColor = Color.red;
    [SerializeField] private Color _maxTruthColor = Color.green;
    
    [Space]
    [SerializeField] private TruthAgent _truthAgent = default;

    [Inject] private TruthDataModel _truthDataModel = default; 
    
    protected void Start()
    {
        _truthAgent.truthUpdatedEvent += HandleTruthAgentTruthUpdated;

        _spriteRenderer.color = _defaultColor;
    }

    protected void OnDestroy()
    {
        if (_truthAgent != null)
        {
            _truthAgent.truthUpdatedEvent -= HandleTruthAgentTruthUpdated;
        }
    }

    private void HandleTruthAgentTruthUpdated(float currentTruth)
    {
        _spriteRenderer.color = Color.Lerp(_noTruthColor, _maxTruthColor, currentTruth / _truthDataModel.GetMaxTruth());
    }

#if UNITY_EDITOR
    protected void OnValidate()
    {
        if (_truthAgent != null)
        {
            return;
        }

        _truthAgent = GetComponent<TruthAgent>();
    }
#endif
}
