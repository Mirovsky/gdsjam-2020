using System;
using UnityEngine;


public class Collider2DEvents : MonoBehaviour
{
    [SerializeField] private bool _filterByTag = default;
    [SerializeField] private string _tag = default;
    
    public event Action<Collider2D> onTriggerEnter;
    public event Action<Collider2D> onTriggerExit;
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (_filterByTag && !other.CompareTag(_tag))
        {
            return;
        }
        
        onTriggerEnter?.Invoke(other);
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (_filterByTag && !other.CompareTag(_tag))
        {
            return;
        }
        
        onTriggerExit?.Invoke(other);
    }
}
