using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelArea : MonoBehaviour
{
    [SerializeField]
    private Collider2D _collider;

    public Collider2D Collider { get => _collider; }
}
