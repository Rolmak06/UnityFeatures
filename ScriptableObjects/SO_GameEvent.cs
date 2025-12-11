using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Game Event", menuName = "ScriptableObjects/Game Event")]
public class SO_GameEvent : MonoBehaviour
{
    public List<Action> Events = new();
    public List<UnityEvent> UnityEvents = new();
    public List<SO_GameEvent> ChildEvents = new();

    public void Subscribe(Action action)
    {
        Events.Add(action);
    }

    public void Unsubscribe(Action action)
    {
        if(Events.Contains(action))
        {
            Events.Remove(action);
        }
    }

    public void Subscribe(UnityEvent action)
    {
        UnityEvents.Add(action);
    }

    public void Unsubscribe(UnityEvent action)
    {
        if(UnityEvents.Contains(action))
        {
            UnityEvents.Remove(action);
        }
    }

    public void Raise()
    {
        foreach (var action in Events)
        {
            action?.Invoke();
        }

        foreach (var unityEvent in UnityEvents)
        {
            unityEvent?.Invoke();
        }

        foreach (var childEvent in ChildEvents)
        {
            childEvent.Raise();
        }
    }
}
