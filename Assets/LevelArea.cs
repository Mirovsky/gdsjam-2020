using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelArea : MonoBehaviour
{
    [SerializeField]
    private Collider2D[] _colliders;

    public Collider2D[] Colliders { get => _colliders; }
}
