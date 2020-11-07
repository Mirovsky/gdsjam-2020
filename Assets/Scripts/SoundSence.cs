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
    public float SensitivityGradient;


    void Start()
    {
    }


    void Update()
    {
    }


    void FixedUpdate() {
    }



    void OnDrawGizmos()
    {
        this._drawSensitivityGizmo();
        this._drawClosestPointGizmo();
    }


    private void _drawSensitivityGizmo()
    {
        var location = this.transform.position;
        var r1 = Mathf.Max(0, this.Sensitivity);
        var r2 = r1 * (this.SensitivityGradient / 100.0f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(location, r1);
        Gizmos.DrawWireSphere(location, r2);
    }

    
    private void _drawClosestPointGizmo()
    {
        var collider = this.SoundMapColider;
        var location = this.transform.position;

        if (!collider) return;

        Vector3 closestPoint = collider.ClosestPoint(location);

        // Gizmos.DrawSphere(location, 0.1f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(closestPoint, 0.1f);

    }
}
