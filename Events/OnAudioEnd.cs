using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnAudioEnd : MonoBehaviour
{
    [SerializeField] UnityEvent onAudioEnd;
    [SerializeField] AudioSource source;
    [SerializeField] bool hasStopped = false;

    void Update()
    {
        if(!hasStopped)
        {
            if(!IsPlaying())
            {
                onAudioEnd?.Invoke();
                hasStopped = true;
            }
        }
    }

    public bool IsPlaying()
    {
        if(source.isPlaying) {return true;}
        else return false;
    }
}
