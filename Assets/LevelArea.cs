using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelArea : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Collider2D _soundCollider;

    public Collider2D Collider => _collider;
    public Collider2D soundCollider => _soundCollider;
}
