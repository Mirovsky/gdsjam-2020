using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;


public class SoundSense : MonoBehaviour
{
    [Header("Sensitivity")]
    [Range(0.0f, 10.0f)]
    public float Sensitivity = 5;
    
    [Range(0.0f, 1.0f)]
    public float SensitivityGradientRange = 0.5f;

    public AnimationCurve SensitivityGradientFunction;

    [EventRef, SerializeField] private string _insideNoiseEventRef = default;
    
    [Inject] private TruthDataModel _truthDataModel = default;
    [Inject] private LevelArea _levelArea = default;

    private FMOD.Studio.EventInstance _insideNoiseEventInstance;

    void Start()
    {
        var eventDesc = RuntimeManager.GetEventDescription(_insideNoiseEventRef);

        eventDesc.createInstance(out _insideNoiseEventInstance);

        _insideNoiseEventInstance.start();
        _insideNoiseEventInstance.setVolume(0.0f);
    }
    
    void Update()
    {
        var sensitivityRatio = getSensitivityRatio();

        _insideNoiseEventInstance.setVolume(sensitivityRatio * 20.0f);

        _truthDataModel.ReduceTruthBy(sensitivityRatio);
    }

    Vector3 GetClosestPoint()
    {
        var collider = _levelArea.soundCollider;
        var location = this.transform.position;

        Vector3 closestPoint = collider.ClosestPoint(location);

        return closestPoint;
    }
    
    private float _getSensitivityOuterRadius()
    {
        return Mathf.Max(0, this.Sensitivity);
    }

    private float _getSensitivityInnerRadius()
    {
        var r = this._getSensitivityOuterRadius();
        return r - r * this.SensitivityGradientRange;
    }
    
    float getSensitivityRatio()
    {
        var location = this.transform.position;
        var closestPoint = this.GetClosestPoint();

        var r1 = this._getSensitivityOuterRadius();
        var r2 = this._getSensitivityInnerRadius();

        float dist = Vector3.Distance(closestPoint, location);

        float linearRatio;

        if (dist < r2) linearRatio = 1;
        else if (dist < r1) linearRatio = 1 - Mathf.Abs(dist - r2) / (r1 - r2);
        else linearRatio = 0;

        var ratio = this.SensitivityGradientFunction.Evaluate(linearRatio);
        // var ratio = linearRatio;

        return ratio;
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        this._drawSensitivityGizmo();
        this._drawClosestPointGizmo();
    }
    
    private void _drawSensitivityGizmo()
    {
        var location = this.transform.position;
        var r1 = this._getSensitivityOuterRadius();
        var r2 = this._getSensitivityInnerRadius();

        var diff = r1 - r2;

        Gizmos.color = diff > 0 ? Color.yellow : Color.red;
        Gizmos.DrawWireSphere(location, r1);

        if (r1 != r2)
        {
            var fce = this.SensitivityGradientFunction;
            Gizmos.DrawWireSphere(location, r2 + diff * fce.Evaluate(0.5f));
            Gizmos.DrawWireSphere(location, r2);    
        }
    }

    private void _drawClosestPointGizmo()
    {
        if (this._levelArea == null || this._levelArea.soundCollider == null) return;

        var location = this.transform.position;
        Vector3 closestPoint = this.GetClosestPoint();

        float maxSize = 0.5f;
        float minSize = 0.1f;

        float ratio = this.getSensitivityRatio();
        float radius = minSize + (maxSize - minSize) * ratio;

        if (ratio > 0) Gizmos.color = Color.yellow;
        else Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(closestPoint, radius);
    }
#endif
}
