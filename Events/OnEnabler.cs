using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnabler : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEnableUnityEvent;

    private void OnEnable()
    {
        _onEnableUnityEvent?.Invoke();
    }
}
