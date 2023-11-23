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

    public List <TimedInvoke> timedEvents;

    public bool onEnable = true;
    // Start is called before the first frame update
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
