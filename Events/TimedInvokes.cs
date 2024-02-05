using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class TimedInvokes : MonoBehaviour
{
    [Serializable]
    public class TimedInvoke
    {
        public float wait;
        public UnityEvent timedEvent;
    }

    [SerializeField] List <TimedInvoke> timedEvents;
    
    [SerializeField, Tooltip("Does the timer starts when this gameobject is enabled ?")] bool onEnable = true;

    void OnEnable()
    {
        if(!onEnable) {return;}
        foreach(TimedInvoke events in timedEvents)
        {
            StartCoroutine(InvokeTimedEvents(events.wait, events.timedEvent));
        }
    }

    public void StartEvents()
    {
        //Starts a timer foreach events listed in the script. Related Unity Events will be invoked.
        foreach(TimedInvoke events in timedEvents)
        {
            StartCoroutine(InvokeTimedEvents(events.wait, events.timedEvent));
        }
    }
    private IEnumerator InvokeTimedEvents(float wait, UnityEvent invoke)
    {
        yield return new WaitForSeconds(wait);
        invoke?.Invoke();
    }
}
