using UnityEngine;


public class Collider2DEvents : MonoBehaviour
{
    [SerializeField] private bool _filterByTag = default;
    [SerializeField] private string _tag = default;
    
    public event System.Action<Collider2D> onTriggerEnter;

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (_filterByTag && !other.CompareTag(_tag))
        {
            return;
        }
        
        onTriggerEnter?.Invoke(other);
    }
}
