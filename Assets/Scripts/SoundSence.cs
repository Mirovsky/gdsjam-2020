using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SoundSence : MonoBehaviour
{
    public TilemapCollider2D SoundMapColider;

    [Range(0.0f, 10.0f)]
    public float Sensitivity;
    
    [Range(0.0f, 100.0f)]
    public float SensitivityGradientRange;


    void Start()
    {
    }


    void Update()
    {
    }


    void FixedUpdate() {
    }


    private Vector3 _getClosestPoint()
    {
        var collider = this.SoundMapColider;
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
        return r - r * (this.SensitivityGradientRange / 100.0f);
    }


    float getSensitivityRatio()
    {
        var location = this.transform.position;
        var closestPoint = this._getClosestPoint();

        var r1 = this._getSensitivityOuterRadius();
        var r2 = this._getSensitivityInnerRadius();

        float dist = Vector3.Distance(closestPoint, location);

        float linearRatio;

        if (dist < r2) linearRatio = 1;
        else if (dist < r1) linearRatio = 1 - Mathf.Abs(dist - r2) / (r1 - r2);
        else linearRatio = 0;

        return linearRatio;
    }


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

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(location, r1);

        if (r1 == r2) Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(location, r2);
    }

    
    private void _drawClosestPointGizmo()
    {
        if (!this.SoundMapColider) return;

        var location = this.transform.position;
        Vector3 closestPoint = this._getClosestPoint();

        float maxSize = 0.25f;
        float minSize = 0.025f;

        float ratio = this.getSensitivityRatio();
        float radius = Mathf.Max(minSize, maxSize * ratio);

        if (ratio > 0) Gizmos.color = Color.yellow;
        else Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(closestPoint, radius);
    }
}
