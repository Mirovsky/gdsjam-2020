using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClickSound : MonoBehaviour
{
    [SerializeField] private Button _button = default;

    [EventRef, SerializeField] private string clickEventRef = default;
    
    void Start()
    {
        _button.onClick.RemoveListener(HandleButtonOnClick);
        _button.onClick.AddListener(HandleButtonOnClick);
    }

    private void HandleButtonOnClick()
    {
        RuntimeManager.PlayOneShot(clickEventRef);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        _button = GetComponent<Button>();
    }
#endif
}
