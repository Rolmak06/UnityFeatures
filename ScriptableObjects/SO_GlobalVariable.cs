using System;
using UnityEngine;

public class SO_GlobalVariable<T> : ScriptableObject
{
    public T Value;
    public Action<T> OnValueChanged;

    public void SetValue(T value)
    {
        if (value.Equals(Value))
            return;

        Value = value;
        OnValueChanged?.Invoke(Value);
    }
}
